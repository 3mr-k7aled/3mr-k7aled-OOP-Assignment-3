
using RefactoringLab;

var shipping = new ShippingCostCalculator(  new IShippingCostStrategy[] 
{
        new AramexShippingStrategy(),
        new FedExShippingStrategy(),
        new DHLShippingStrategy()
} );

Console.WriteLine($"Aramex 2kg => {shipping.Calculate("Aramex", 2)}");

Console.WriteLine( $"FedEx 2kg => {shipping.Calculate("FedEx", 2)}");

Console.WriteLine( $"DHL 2kg => {shipping.Calculate("DHL", 2)}");


var processor = new OrderProcessor(
    new SqlOrderRepository(),
    new SmtpEmailSender());

processor.Process(1001, "Amr@example.com");


var emailNotification = new Notification(
    new EmailNotificationChannel(),
    true,
    DateTime.Today.AddHours(15));

emailNotification.Send(
    "Amr@example.com",
    "Your order ships tomorrow");


var smsNotification = new Notification(
    new SmsNotificationChannel(),
    true);

smsNotification.Send(
    "+20153477750",
    "OTP 46721");