### Sakimori Souka // 防人想歌

##### onoken feat. Natsukawa Yoko // 夏川陽子

---

##### Youtube Preview

[![Youtube Preview](https://i.imgur.com/kqeXhX9.png)](https://www.youtube.com/watch?v=vObrA4xrPe4 "Youtube Preview")

##### Main

* `Main.cs` includes the dark and light variants of the background
* the dark variant is kept constantly visible and the light variant is drawn above during choruses
* this is the layer that is drawn below everything else
* there are no configurable properties for this script as it is not intended to be used in other projects

##### bounce

* `bounce.cs` contains a bounce-like effect used during the last kiai as emphasis
* it consists of a slight increase to the background's scale while fading it out at the same time
* configurable properties are documented in the file's comments

##### myLyrics
* `myLyrics.cs` contains all the effects I used to generate lyrics
* this effect contains 3 different styles which are denoted here as *normal*, *chorus*, and *huge*
* `/lyrics` contains the individual subtitle files that the sprites are generated from
  * the subtitles are based off of the lyrics provided on [RemyWiki](https://remywiki.com/Sakimori_souka) and formatted into .ass files by myself
* the normal lyrics section is largely copied directly from the template `Lyrics.cs` file
  * the lyrics for this section were written line by line
* the huge lyrics section is very similar, just with an additional scaling effect
  * however, these lyrics were written character by character and they spawn one after another right in the centre of the screen
* the chorus lyrics section is kind of a disaster
  * these lyrics were written character by character but grouped into "lines" as I intended them to show up
  * the last character in one of these "lines" is followed by a `*` character which is used in the code to set the position offsets properly
  * the timestamps for these lyrics were manually edited in Aegissub with all characters on one line overlapping to all end only once the last character ends
* configurable properties are documented in the file's comments