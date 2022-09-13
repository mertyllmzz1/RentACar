namespace UIWeb.Helpers
{
    public class ImageLoad
    {
        public static string Load(IFormFile images)
        {
            string[] path = { ".jpg", ".jpeg",".png" };
            string Uzanti = "";
            string NewName = "";
            string KayitAdresi = "";
            if (images != null)
            {
                Uzanti = Path.GetExtension(images.FileName);
                if (path.Contains(Uzanti))
                {
                    NewName = Guid.NewGuid() + Uzanti;
                    KayitAdresi = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/" + NewName);
                    using (FileStream stream = new FileStream(KayitAdresi, FileMode.Create))
                    {
                        images.CopyTo(stream);
                    }
                    return NewName;
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "1";
            }
        }

        public static void ImagesDelete(string ImagesDelete)
        {
            if (!string.IsNullOrEmpty(ImagesDelete))
            {
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/" + ImagesDelete));

            }
        }
    }
}
