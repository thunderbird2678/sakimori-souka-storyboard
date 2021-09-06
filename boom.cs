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
    public class boom : StoryboardObjectGenerator
    {
        [Configurable]
        public int Time = 0;

        [Configurable]
        public int FadeDuration = 200;

        [Configurable]
        public string SpritePath = "sb/glow.png";

        [Configurable]
        public double SpriteScale = 1;

        public override void Generate()
        {
            var hitobjectLayer = GetLayer("");
            foreach (var hitobject in Beatmap.HitObjects)
            {
                if(hitobject is OsuSlider)
                {
                    if(hitobject.StartTime <= Time+5 && hitobject.EndTime >= Time-5)
                    {
                        var hSprite = hitobjectLayer.CreateSprite(SpritePath, OsbOrigin.Centre, hitobject.PositionAtTime(Time));
                        hSprite.Scale(OsbEasing.In, Time, Time + FadeDuration, SpriteScale, SpriteScale * 0.2);
                        hSprite.Fade(OsbEasing.In, Time, Time + FadeDuration, 1, 0);
                        hSprite.Additive(Time, Time + FadeDuration);
                        hSprite.Color(Time, new Color4(253, 234, 255, 255));
                    }

                }
                else
                {
                    if(hitobject.StartTime == Time)
                    {
                        var hSprite = hitobjectLayer.CreateSprite(SpritePath, OsbOrigin.Centre, hitobject.Position);
                        hSprite.Scale(OsbEasing.In, Time, Time + FadeDuration, SpriteScale, SpriteScale * 0.2);
                        hSprite.Fade(OsbEasing.In, Time, Time + FadeDuration, 1, 0);
                        hSprite.Additive(Time, Time + FadeDuration);
                        hSprite.Color(Time, new Color4(253, 234, 255, 255));
                    }
                }
            }
        }
    }
}