
string imagesPath = Path.GetDirectoryName(AppContext.BaseDirectory);
string backupPath = Path.Combine(imagesPath, "Backup-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm"));
string turntablePath = Path.Combine(imagesPath, "Turntable-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm"));


string[] imageExtensions = { ".jpg", ".jpeg", ".png" };

string[] imageFiles = Directory.GetFiles(imagesPath)
	.Where(file => imageExtensions.Contains(Path.GetExtension(file).ToLower()))
	.ToArray();

if(imageFiles.Length == 0)
	return;

if (!Directory.Exists(backupPath))
	Directory.CreateDirectory(backupPath);


if (!Directory.Exists(turntablePath))
	Directory.CreateDirectory(turntablePath);


int counter = 0;

foreach (string imagePath in imageFiles)
{
	string fileName = Path.GetFileNameWithoutExtension(imagePath);
	string fileExtension = Path.GetExtension(imagePath);
	string backupFilePath = Path.Combine(backupPath, fileName + fileExtension);
	string turntableFilePath = Path.Combine(turntablePath, "Turntable-" + counter.ToString("D2") + fileExtension);

	File.Copy(imagePath, backupFilePath);
	File.Move(imagePath, turntableFilePath);
	counter++;
}

Console.WriteLine("Image renaming completed.");