
namespace RefactoringLab.Part_3.Enrollment;

public class EnrollmentFacade
{
    private readonly PaymentGateway paymentGateway = new PaymentGateway();
    private readonly SeatInventory seatInventory = new SeatInventory();
    private readonly InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
    private readonly EmailService emailService = new EmailService();

    public void Enroll(string studentId, string courseId, decimal amount)
    {
        paymentGateway.Charge(studentId, amount);

        seatInventory.Reserve(courseId, studentId);

        var invoiceId = invoiceGenerator.Create(studentId, amount);

        emailService.Send(studentId, "Enrollment completed Successfully", $"Your invoice is {invoiceId}");
    }
}