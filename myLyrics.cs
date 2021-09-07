// written by thunderbird2678
// you can contact me on twitter @thunderbird2678 or on discord (thunderbird#2678)
// feel free to use any or all parts of this storyboard code however you wish

using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;
namespace StorybrewScripts
{

    public class MyLyrics : StoryboardObjectGenerator
    {
        [Configurable]
        // a string containing a path to the normal-sized lyrics
        public string lyricsNormalStr = "lyrics/lyricNormal.ass";

        [Configurable]
        // a string containing a path to the chorus-sized lyrics
        public string lyricsChorusStr = "lyrics/lyricChorus.ass";

        [Configurable]
        // a string containing a path to the huge-sized lyrics
        public string lyricsHugeStr = "lyrics/lyricHuge.ass";

        [Configurable]
        // a string containing a path to the font used
        public string fontPathStr = "nagayama_kai08.otf";

        [Configurable]
        // an integer containing the size of the normal font
        public int normalSize = 26;

        [Configurable]
        // an integer containing the size of the chorus font
        public int chorusSize = 56;

        [Configurable]
        // an integer containing the size of the huge font
        public int hugeSize = 144;

        [Configurable]
        // an integer containing the thickness of the shadow used on the huge font
        public int normalShadowSize = 10;

        [Configurable]
        // an integer containing the thickness of the shadow used on the huge font
        public int chorusShadowSize = 10;

        [Configurable]
        // an integer containing the thickness of the shadow used on the huge font
        public int hugeShadowSize = 10;

        public override void Generate()
        {
            var layer = GetLayer("Main");

            // load the lyrics from the respective files
            var lyricsNormal = LoadSubtitles(lyricsNormalStr);
            var lyricsChorus = LoadSubtitles(lyricsChorusStr);
            var lyricsHuge = LoadSubtitles(lyricsHugeStr);

            // initialize the fonts used
            var fontNormal = LoadFont("sb/lyrics/normal", new FontDescription()
            {
                FontPath = fontPathStr,
                FontSize = normalSize,
                Color = new Color4(255, 255, 255, 255),
            },
            new FontShadow()
            {
                Thickness = normalShadowSize,
                Color = new Color4(0, 0, 0, 255),
            });
            var fontChorus = LoadFont("sb/lyrics/chorus", new FontDescription()
            {
                FontPath = fontPathStr,
                FontSize = chorusSize,
                Color = new Color4(255, 255, 255, 255),
            },
            new FontShadow()
            {
                Thickness = chorusShadowSize,
                Color = new Color4(0, 0, 0, 255),
            });
            var fontHuge = LoadFont("sb/lyrics/huge", new FontDescription()
            {
                FontPath = fontPathStr,
                FontSize = hugeSize,
                Color = new Color4(255, 255, 255, 255),
            },
            new FontShadow()
            {
                Thickness = hugeShadowSize,
                Color = new Color4(0, 0, 0, 255),
            });

            // iterate through every line in the normal lyrics
            foreach (var line in lyricsNormal.Lines)
            {
                // create texture using the selected font then draw the sprite
                var texture = fontNormal.GetTexture(line.Text);
                var sprite = layer.CreateSprite(texture.Path, OsbOrigin.CentreLeft, new Vector2(100, 150));
                // basic fade in/out effect
                sprite.Fade(line.StartTime - 200, line.StartTime, 0, 1);
                sprite.Fade(line.EndTime - 200, line.EndTime, 1, 0);
            }

            // ** the way I set up this section is ridiculously janky but it works for my uses
            // ** go through the readme for documentation

            // counter variable
            var i = 0;
            // boolean flag to reset counter
            var reset = false;
            // iterate through chorus lyrics
            foreach (var line in lyricsChorus.Lines)
            {
                // grab the text
                var text = line.Text;
                // if the text contains my EOL symbol, cut the symbol and mark this as a reset point
                if (text.Contains('*'))
                {
                    text = text.Remove(text.Length - 1, 1);
                    reset = true;
                }

                // create texture using the selected font
                var texture = fontChorus.GetTexture(text);

                // verify that the texture path is not null as this loop will encounter null chars
                if (texture.Path != null)
                {
                    // draw the selected sprite
                    var sprite = layer.CreateSprite(texture.Path, OsbOrigin.CentreLeft, new Vector2(100 + i, 150));

                    // basic fade in / out effect
                    sprite.Fade(line.StartTime - 200, line.StartTime, 0, 1);
                    sprite.Fade(line.EndTime - 200, line.EndTime, 1, 0);

                    // scaling effect
                    sprite.Scale(OsbEasing.Out, line.StartTime - 200, line.StartTime, Random(15, 20), 1);

                    // horizontal offset so that "lines" will be drawn next to each other until EOL
                    i += 75;
                }

                // once the reset flag is triggered
                if (reset)
                {
                    // reset the horizontal offset
                    i = 0;
                    // set the flag back to false
                    reset = false;
                }
            }

            // iterate through every line in the huge lyrics
            foreach (var line in lyricsHuge.Lines)
            {
                // create texture using the selected font and then draw the sprite
                var texture = fontHuge.GetTexture(line.Text);

                // note this sprite is drawn exactly at the centre of the screen
                var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre);

                // basic fade in / out effect
                sprite.Fade(line.StartTime - 200, line.StartTime, 0, 1);
                sprite.Fade(line.EndTime - 200, line.EndTime, 1, 0);

                // scaling effect
                sprite.Scale(OsbEasing.Out, line.StartTime - 200, line.StartTime, Random(25, 35), 1);
            }
        }
    }
}
