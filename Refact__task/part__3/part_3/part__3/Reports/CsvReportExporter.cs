
namespace RefactoringLab.Part_3.Reports;

public class CsvReportExporter : ReportExporter
{
    protected override string Format(List<string[]> rows) =>
        string.Join(Environment.NewLine, rows.Select(r => string.Join(",", r)));
}