using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SICUENSA.Models.Entities.BdSicuensa;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace SICUENSA.Repositories.Services;

public class ReportService
{
    private readonly DbContextSicuensa _db;

    public ReportService(DbContextSicuensa db) => _db = db;

    public async Task<byte[]> GenerateExcelReportAsync()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Solo válido en v5.x
        using var package = new ExcelPackage(new MemoryStream());

        var worksheet = package.Workbook.Worksheets.Add("Instalaciones");

        worksheet.Cells[1, 1].Value = "ID";
        worksheet.Cells[1, 2].Value = "Nombre";
        worksheet.Cells[1, 3].Value = "Nivel";
        worksheet.Cells[1, 4].Value = "Tipo";

        var instalaciones = await _db.Instalaciones.ToListAsync();
        for (int i = 0; i < instalaciones.Count; i++)
        {
            worksheet.Cells[i + 2, 1].Value = instalaciones[i].InstalacionSaludId;
            worksheet.Cells[i + 2, 2].Value = instalaciones[i].InstalacionSalud;
            worksheet.Cells[i + 2, 3].Value = instalaciones[i].NivelInstalacion;
            worksheet.Cells[i + 2, 4].Value = instalaciones[i].TipoInstalacion;
        }

        return package.GetAsByteArray();
    }
}