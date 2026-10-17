
## Notifications

## What was the problem ?

The original notification design used inheritance to show different kinds of notification as channels, urgency, and scheduling

This created lots of  multiple classes with the same behaviors and made the design harder to extend and unreadable

## solution =>

I changed inheritiance idea into using the INotificationChannel interface and separate channel implementations for email and SMS

I refactored the Notification class to use composition, receiving a notification channel and the required notification options through its constructor

This reduced the need for separate classes for every combination of channel, urgency, and scheduling, following the Composition over Inheritance 