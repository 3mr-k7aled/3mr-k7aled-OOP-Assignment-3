
namespace RefactoringLab;

public interface INotificationChannel
{
    void Send(string to, string message);
}

public class EmailNotificationChannel : INotificationChannel
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"[email] {to}: {message}");
    }
}

public class SmsNotificationChannel : INotificationChannel
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"[sms] {to}: {message}");
    }
}

public class Notification
{
    private readonly INotificationChannel _channel;
    private readonly bool _isUrgent;
    private readonly DateTime? _sendAt;

    public Notification(
        INotificationChannel channel,
        bool isUrgent = false,
        DateTime? sendAt = null)
    {
        _channel = channel;
        _isUrgent = isUrgent;
        _sendAt = sendAt;
    }

    public void Send(string to, string message)
    {
        if (_isUrgent)
        {
            message = $"[URGENT] {message}";
        }

        if (_sendAt.HasValue)
        {
            Console.WriteLine(
                $"[Scheduled: {_sendAt.Value:g}]");
        }

        _channel.Send(to, message);
    }
}