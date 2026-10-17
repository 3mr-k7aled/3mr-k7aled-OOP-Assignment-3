
namespace RefactoringLab.Part_3.Reports;

public class JsonReportExporter : ReportExporter
{
    protected override string Format(List<string[]> rows)
    {
        var items = rows.Select(r => $"{{\"Id\":\"{r[0]}\",\"Name\":\"{r[1]}\"}}");

        return "[" + string.Join(",", items) + "]";
    }
}