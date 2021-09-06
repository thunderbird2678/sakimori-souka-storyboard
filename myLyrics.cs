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
        public override void Generate()
        {

            var layer = GetLayer("Main");

            var lyricsIntro = LoadSubtitles("lyricIntro.ass");
            var lyricsChorus = LoadSubtitles("lyricChorus.ass");
            var lyricsHuge = LoadSubtitles("lyricHuge.ass");

            var fontNormal = LoadFont("sb/lyrics/normal", new FontDescription() {
                FontPath = "nagayama_kai08.otf",
                FontSize = 26,
                Color = new Color4(255,255,255,255),
            });
            var fontChorus = LoadFont("sb/lyrics/chorus", new FontDescription() {
                FontPath = "nagayama_kai08.otf",
                FontSize = 56,
                Color = new Color4(255,255,255,255),
            });
            var fontHuge = LoadFont("sb/lyrics/huge", new FontDescription() {
                FontPath = "nagayama_kai08.otf",
                FontSize = 144,
                Color = new Color4(253, 234, 255, 255),
            },
            // new FontOutline()
            // {
            //     Thickness = 10,
            //     Color = new Color4(253, 234, 255, 255),
            // },
            new FontShadow()
            {
                Thickness = 10,
                Color = new Color4(0,0,0,255),
            });

            foreach (var line in lyricsIntro.Lines)
            {
                var texture = fontNormal.GetTexture(line.Text);
                var sprite = layer.CreateSprite(texture.Path, OsbOrigin.CentreLeft, new Vector2(100,150));
                sprite.Fade(line.StartTime - 200, line.StartTime, 0, 1);
                sprite.Fade(line.EndTime - 200, line.EndTime, 1, 0);
            }

            var i = 0;
            var reset = false;
            foreach (var line in lyricsChorus.Lines)
            {

                var text = line.Text;
                if(text.Contains('*'))
                {
                    text = text.Remove(text.Length - 1, 1);
                    reset = true;
                }

                var texture = fontChorus.GetTexture(text);
                if(texture.Path != null)
                {
                    var sprite = layer.CreateSprite(texture.Path, OsbOrigin.CentreLeft, new Vector2(100+i,150));
                    sprite.Fade(line.StartTime - 200, line.StartTime , 0, 1);
                    sprite.Fade(line.EndTime - 200, line.EndTime, 1, 0);
                    sprite.Scale(OsbEasing.Out, line.StartTime - 200, line.StartTime, Random(5,30), 1);
                    i += 75;
                }

                if(reset)
                {
                    i = 0;
                    reset = false;
                }
            }

            foreach (var line in lyricsHuge.Lines)
            {
                var texture = fontHuge.GetTexture(line.Text);
                var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre);
                sprite.Fade(line.StartTime - 200, line.StartTime, 0, 1);
                sprite.Fade(line.EndTime - 200, line.EndTime, 1, 0);
                sprite.Scale(OsbEasing.Out, line.StartTime - 200, line.StartTime, Random(20,30), 1);
            }
        }
    }
}
