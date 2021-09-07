### Sakimori Souka // 防人想歌

##### onoken feat. Natsukawa Yoko // 夏川陽子

---

##### Youtube Preview

[![Youtube Preview](https://img.youtube.com/vi/vObrA4xrPe4/hqdefault.jpg)](https://www.youtube.com/watch?v=vObrA4xrPe4 "Youtube Preview")

##### Main

* `Main.cs` includes the dark and light variants of the background
* the dark variant is kept constantly visible and the light variant is drawn above during choruses
* this is the layer that is drawn below everything else
* there are no configurable properties for this script as it is not intended to be used in other projects

##### bounce

* `bounce.cs` contains a bounce-like effect used during the last kiai as emphasis
* it consists of a slight increase to the background's scale while fading it out at the same time
* configurable properties are as follows:
    * `bg` - **string**, path to the background image used for the effect
    * `beatDivisor` - **int**, the beat subdivisor that will be used to control fade and scale in/out duration
    * `scaleDuration` - **int**, the number of subdivisions after which the scaling effect ends
    * `fadeDuration` - **int**, the number of subdivisions after which the fading effect ends
    * `scaleStart` - **double**, the scaling factor of the image at the beginning of the effect
    * `scaleEnd` - **double**, the scaling factor of the image at the end of the effect=