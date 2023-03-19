using EmlParser.Types;
using MimeKit;


using var stream = File.OpenRead("test.eml");

var mimeMessage = MimeMessage.Load(stream);

var message = new Message();

message.Subject = mimeMessage.Subject;
message.From = new User
{
    Email = mimeMessage.From.Mailboxes.First().Address,
    Name = mimeMessage.From.Mailboxes.First().Name
};

foreach(var to in mimeMessage.To.Mailboxes)
{
    message.To.Add(new User
    {
        Email = to.Address, 
        Name = to.Name
    });
}
message.Content = mimeMessage.TextBody ?? mimeMessage.HtmlBody ;

foreach (var attachment in mimeMessage.Attachments)
{
    var fileName = "attached-message.eml";

    if (attachment is MessagePart messagePart)
    {
        fileName = attachment.ContentDisposition?.FileName;
     

        if (string.IsNullOrEmpty(fileName))
           

        using (var fileStream = File.Create(fileName))
            messagePart.Message.WriteTo(stream);
    }
    else
    {
        var part = attachment as MimePart;
        fileName = part.FileName;

        using (var fileStream = File.Create(fileName))
            part.Content.DecodeTo(fileStream);
    }
    message.Attachments.Add(new Attachment
    {
        FileName = fileName,
        FullName = new FileInfo(fileName).FullName,
    });
}



Console.WriteLine(message);