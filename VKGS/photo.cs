namespace VKGS
{
    internal class Photo
    {
        private string path = Directory.GetCurrentDirectory();
        private void photocreate()
        {
            DirectoryInfo dir = new DirectoryInfo($"{path}/Photos");
            dir.Create();
        }
        private void PhotoDir()
        {
            photocreate();
            Console.WriteLine($"Поместите фото (До 5 штук) в папку Photo и нажмите Enter");
            string[] dirs = Directory.GetDirectories(path, "Photos*.");
            foreach (string dir in dirs)
            {
                System.Diagnostics.Process.Start("explorer.exe", dir);
            }
            Console.ReadLine();
        }
        public byte[][] photoset()
        {
            PhotoDir();
            var directory = new DirectoryInfo($"{path}/Photos");
            FileInfo[] Photos = directory.GetFiles();
            byte[][] photos = new byte[5][];
            int i = 0;
            try
            {
                foreach (FileInfo photo in Photos)
                {
                    Console.WriteLine(photo.Name);
                    byte[] PData = File.ReadAllBytes(photo.FullName);
                    photos[i] = PData;
                    i++;
                }
            }
            catch (Exception) { return photos; }
            return photos;
        }
    }
}
