﻿using Microsoft.Xna.Framework;
using StickyHandGame_C9_RP7.Source.MathmaticHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyHandGame_C9_RP7.Source.Components.DynamicLighting
{
    public enum TraceType { Line, Ray, undefined }
    public class Trace
    {
        private static int id = 1;
        public int myid = 0;
        public TraceType mytraceType;
        public Vector2 StartPoint;
        public Vector2 Extend;
        public Trace(TraceType mytype) { this.mytraceType = mytype; }
        public Trace(TraceType type, Vector2 Start, Vector2 Extend)
        {
            this.mytraceType = type;
            this.StartPoint = Start;
            this.Extend = Extend;
            this.myid = Trace.id;
            Trace.id++;
        }
        public Trace(Vector2 Start, Vector2 End)
        {
            this.mytraceType = TraceType.Line;
            this.StartPoint = Start;
            this.Extend = End - Start;
        }
        public float IntersetDetection(Trace Line)
        {
            return IntersectDetection.IntersetDetection(this, Line);
        }
        public static Vector2 EndPoint(Trace Line)
        {
            return Line.StartPoint + Line.Extend;
        }
        public static List<Trace> PolyGonToLines(List<Vector2> Polygon)
        {
            Debug.Assert(Polygon.Count == 4, "Wrong Polygon size");
            List<Trace> result = new List<Trace>();
            for (int i = 0; i < 3; i++)
            {
                Trace line = new Trace(TraceType.Line, Polygon[i], Polygon[i + 1] - Polygon[i]);
                result.Add(line);
            }
            result.Add(new Trace(TraceType.Line, Polygon[3], Polygon[0] - Polygon[3]));

            return result;
        }
        public static List<Vector2> HullTOpoint(Hull hull)
        {
            List<Vector2> points = new List<Vector2>();
            List<Trace> sides = hull.Sides;
            foreach (Trace t in sides)
            {
                points.Add(t.StartPoint);
            }
            return points;
        }
        public String ToString
        {
            get
            {
                return "Start" + this.StartPoint + "Extend" + this.Extend;
            }
        }
        /*public static Trace Copy(Trace trace) {
            return new Trace(trace.mytraceType, trace.StartPoint, trace.Extend);
        }
        public static List<Trace> Copy(List<Trace> traces)
        {
            List<Trace> NewTraces = new List<Trace>();
            foreach (Trace tra in traces) {
                NewTraces.Add(Trace.Copy(tra));
            }
            return NewTraces;
        }*/
    }
}
