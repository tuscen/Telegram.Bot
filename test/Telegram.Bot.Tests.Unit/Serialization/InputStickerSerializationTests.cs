using System.IO;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Xunit;

namespace Telegram.Bot.Tests.Unit.Serialization;

public class InputStickerSerializationTests
{
    [Fact(DisplayName = "Should serialize & deserialize input sticker from input file stream")]
    public void Should_Serialize_InputFile()
    {
        const string fileName = "myFile";
        InputFileStream inputFile = new(new MemoryStream(), fileName);
        string[] emojiList = ["🙂"];
        InputSticker inputSticker = new(inputFile, emojiList);

        string json = Serializer.Serialize(inputSticker);
        InputSticker obj = Serializer.Deserialize<InputSticker>(json)!;

        InputFileStream objInputFile = (InputFileStream)obj.Sticker;

        Assert.Equal(emojiList, obj.EmojiList);
        Assert.Contains(@$"""sticker"":""attach://{fileName}""", json);
        Assert.Equal(Stream.Null, objInputFile.Content);
        Assert.Equal(fileName, objInputFile.FileName);
        Assert.Equal(FileType.Stream, objInputFile.FileType);
    }

    [Fact(DisplayName = "Should serialize & deserialize input sticker with input file id")]
    public void Should_Serialize_FileId()
    {
        const string fileId = "This-is-a-file_id";
        InputFileId inputFileId = new(fileId);
        string[] emojiList = ["🙂"];
        InputSticker inputStickerFileId = new(inputFileId, emojiList);

        string json = Serializer.Serialize(inputStickerFileId);
        InputSticker? obj = Serializer.Deserialize<InputSticker>(json);

        InputFileId? objInputFileId = (InputFileId?)obj?.Sticker;

        Assert.NotNull(obj);
        Assert.Equal(emojiList, obj.EmojiList);
        Assert.NotNull(objInputFileId);
        Assert.Contains(@$"""sticker"":""{fileId}""", json);
        Assert.Equal(fileId, objInputFileId.Id);
        Assert.Equal(FileType.Id, objInputFileId.FileType);
    }

    [Fact(DisplayName = "Should serialize & deserialize input sticker with input file URL")]
    public void Should_Serialize_InputUrlFile()
    {
        Uri url = new("http://github.org/TelegramBots");
        InputFileUrl inputFileUrl = new(url);
        string[] emojiList = ["🙂"];
        InputSticker inputStickerFileUrl = new(inputFileUrl, emojiList);

        string json = Serializer.Serialize(inputStickerFileUrl);
        InputSticker? obj = Serializer.Deserialize<InputSticker>(json);

        InputFileUrl? objInputFileUrl = (InputFileUrl?)obj?.Sticker;

        Assert.NotNull(obj);
        Assert.Equal(emojiList, obj.EmojiList);
        Assert.NotNull(objInputFileUrl);
        Assert.Contains(@$"""sticker"":""{url}""", json);
        Assert.Equal(url, objInputFileUrl.Url);
        Assert.Equal(FileType.Url, objInputFileUrl.FileType);
    }
}
