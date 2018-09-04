using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyHandGame_C9_RP7.Source.Components.DynamicLighting
{
    public class Hull
    {
        public List<Trace> Sides;
        public List<Trace> Bound;
        public int id;
        public static int count = 0;
        public Hull(List<Trace> sides)
        {
            this.Sides = sides;
            this.id = Hull.count;
            this.Bound = new List<Trace>();
            Hull.count++;
        }
        public bool Equal(Hull another)
        {
            if (this.id == another.id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Update()
        {
            this.Bound = new List<Trace>();
        }
        public void DrawHull(Hull hull, SpriteBatch spriteBatch)
        {
            Vector2 temp = new Vector2(0, 0);
            Polygon poly = new Polygon(Trace.HullTOpoint(hull));
            MonoGame.Extended.ShapeExtensions.FillRectangle(spriteBatch, new RectangleF(hull.Sides[0].StartPoint.X,
                hull.Sides[0].StartPoint.Y,
                hull.Sides[0].Extend.X,
                hull.Sides[1].Extend.Y), Color.Black);
            foreach (Trace t in hull.Sides)
            {
                temp = t.Extend;
                temp.Normalize();
                MonoGame.Extended.ShapeExtensions.DrawLine(spriteBatch, t.StartPoint - temp * 2, Trace.EndPoint(t) + temp * 2, Color.Green, 2);
            }
        }
        /*public static Hull Copy(Hull hull) {
            return new Hull(hull.Sides);
        }
        public static List<Hull> Copy(List<Hull> Hulls) {
            List<Hull> NewHalls = new List<Hull>();
            foreach (Hull h in Hulls) {
                NewHalls.Add(Hull.Copy(h));
            }
            return NewHalls;
        }*/
    }
}
