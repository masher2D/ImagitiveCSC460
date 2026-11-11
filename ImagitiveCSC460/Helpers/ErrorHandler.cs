namespace ImagitiveCSC460UI.Helpers;

public static class ErrorHandler
{
    public static void Handle(Exception ex)
    {
        MessageBox.Show(
            ex.Message,
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}