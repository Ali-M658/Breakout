namespace WindowsFormsApp
{
    public class ResizeHandler
    {
        public void ResizeHandlers(Form form, Panel[] panels)
        {
            int maxWidth = 1920;
            int maxHeight = 1080;
            // Clamp the form size to the maximum values
            form.Width = Math.Min(form.Width, maxWidth);
            form.Height = Math.Min(form.Height, maxHeight);

            // Calculate the scaling ratios based on the new form size
            double ratioX = (double)form.Width / 800;
            double ratioY = (double)form.Height / 600;
            
            // Resize each panel based on the scaling ratios
            foreach (var panel in panels)
            {
                // Get the original location and size of the panel
                int originalX = panel.Location.X;
                int originalY = panel.Location.Y;
                int originalWidth = panel.Size.Width;
                int originalHeight = panel.Size.Height;

                // Calculate the new panel location and size
                int newX = (int)(originalX * ratioX);
                int newY = (int)(originalY * ratioY);
                int newWidth = (int)(originalWidth * ratioX);
                int newHeight = (int)(originalHeight * ratioY);

                // Apply minimum width and height constraints
                newWidth = Math.Max(newWidth, 100);
                newHeight = Math.Max(newHeight, 20);

                // Update the panel's bounds
                panel.SetBounds(newX, newY, newWidth, newHeight);
            }
        }
    }
}