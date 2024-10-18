using FluentFTP;

var client = new FtpClient("ftp://ftp.kazachya.net");

client.Connect();

var status = client.DownloadFile(
    localPath: "download.mp3",
    remotePath: @"/Music/Music/Music/ATB/Millennium Remixes/atb-bob_marley__sun_is_shining_a.mp3"
);

System.Console.WriteLine(status);

// 1 download
// https://www.mmnt.ru/