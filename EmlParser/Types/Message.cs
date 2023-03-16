using ReadSharp;
using System.Text;

namespace EmlParser.Types;
internal record Message
{
    public User From { get; set; } = new();
    public  HashSet<User> To { get; set; } = new();
    public string Subject { get; set; } = string.Empty;
    public  HashSet<Attachment> Attachments { get; set; } = new();
    public string Content { get; set; } = string.Empty;

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Тема: {Subject}");
        sb.AppendLine( $"От:");
        sb.AppendLine($"\t{From.Name} {From.Email}");
        sb.AppendLine("Для:");
        sb.AppendLine(string.Join("", To.Select(u=>$"\n\t{u.Name} {u.Email}")));
        sb.AppendLine("Письмо:");
        sb.AppendLine(string.Join("\n\t", HtmlUtilities.ConvertToPlainText(Content).Split("\n")));
        if (Attachments.Any())
        {
            sb.AppendLine("Вложения: ");
            sb.AppendLine(string.Join("", Attachments.Select(u => $"\n\t{u.FileName}")));
        }
        return sb.ToString();
    }
}
