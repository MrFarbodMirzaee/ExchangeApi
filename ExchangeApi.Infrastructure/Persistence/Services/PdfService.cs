using System.Collections;
using System.Reflection;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using Document = QuestPDF.Fluent.Document;

namespace ExchangeApi.Infrastructure.Persistence.Services;

public class PdfService(AppDbContext context) : IPdfService
{
    public byte[] GeneratePdf<TEntity>(string title) where TEntity : class
    {
        var data = context
                .Set<TEntity>()
                .ToList();

        var properties = typeof(TEntity)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => !typeof(ICollection).IsAssignableFrom(p.PropertyType) 
                        && p.PropertyType.IsClass) 
            .ToList();

        var document = Document
                .Create(container =>
        {
         container.Page(page =>
        {
            page.Size(PageSizes.A4.Landscape());
            page.Margin(3, Unit.Centimetre);
            page.DefaultTextStyle(x => x.FontSize(12));

            page.Header()
                .Element(CellTitleStyle)
                .Text(title)
                .Bold()
                .FontSize(22)
                .FontColor(Colors.Black)
                .AlignCenter();
            
            var maxLength = 
                properties
                    .Max(p => p.Name.Length);
            
            page.Content().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    foreach (var prop in properties)
                    {
                        var weight = (float)prop.Name.Length / maxLength;
                        columns.RelativeColumn();
                    }
                });

                table.Header(header =>
                {
                    foreach (var prop in properties)
                    {
                        header.Cell().Element(CellHeaderStyle).Text(prop.Name).Bold();
                    }
                });

                foreach (var item in data)
                {
                    foreach (var prop in properties)
                    {
                        var value = prop.GetValue(item);
                        table.Cell().Element(CellStyle).Text(value).FontSize(12);
                    }
                }

                static IContainer CellStyle(IContainer container)
                {
                    return container
                        .Padding(5)
                        .AlignCenter();
                }
                static IContainer CellHeaderStyle(IContainer container)
                {
                    return container
                        .Padding(5)
                        .PaddingBottom(10)
                        .BorderBottom(1)
                        .AlignCenter()
                        .BorderColor(Colors.Grey.Lighten5);
                }
               
            });
            static IContainer CellTitleStyle(IContainer container)
            {
                return container
                    .Padding(5)
                    .PaddingBottom(20)
                    .AlignCenter();
            }
            page.Footer().AlignCenter().Text(x =>
            {
                x.CurrentPageNumber();
                x.Span(" / ");
                x.TotalPages();
            });
        });
    });

    return document.GeneratePdf();
    }
}