using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DDZD
{
    public static class CircleRenderer
    {
        public static void DrawCircleF(
            GraphicsDevice graphicsDevice,
            Vector2 center,
            float radius, float resolution,
            Color color,
            Effect effect,
            Matrix world, Matrix view, Matrix projection)
        {
            var last = Vector2.UnitX * radius;
            var lastP = Perpendicular(last);

            for (var i = 1; i <= resolution; i++)
            {
                var at = AngleToVector(i * MathHelper.PiOver2 / resolution, radius);
                var atP = Perpendicular(at);


                TriangleRenderer.DrawTriangleF(
                    graphicsDevice,
                    new Vector3(center + last, 0), new Vector3(center + at, 0), new Vector3(center, 0),
                    color,
                    effect,
                    world, view, projection
                );
                TriangleRenderer.DrawTriangleF(
                    graphicsDevice,
                    new Vector3(center - last, 0), new Vector3(center - at, 0), new Vector3(center, 0),
                    color,
                    effect,
                    world, view, projection
                );
                TriangleRenderer.DrawTriangleF(
                    graphicsDevice,
                    new Vector3(center + lastP, 0), new Vector3(center + atP, 0), new Vector3(center, 0),
                    color,
                    effect,
                    world, view, projection
                );
                TriangleRenderer.DrawTriangleF(
                    graphicsDevice,
                    new Vector3(center - lastP, 0), new Vector3(center - atP, 0), new Vector3(center, 0),
                    color,
                    effect,
                    world, view, projection
                );

                last = at;
                lastP = atP;
            }
        }

        public static void DrawCircleH(
            GraphicsDevice graphicsDevice,
            Vector2 center,
            float radius, float resolution,
            Color color,
            Effect effect,
            Matrix world, Matrix view, Matrix projection)
        {
            var last = Vector2.UnitX * radius;
            var lastP = Perpendicular(last);

            for (var i = 1; i <= resolution; i++)
            {
                var at = AngleToVector(i * MathHelper.PiOver2 / resolution, radius);
                var atP = Perpendicular(at);

                LineRenderer.DrawLine(
                    graphicsDevice,
                    new Vector3(center + last, 0),
                    new Vector3(center + at, 0),
                    color,
                    effect,
                    world, view, projection);
                LineRenderer.DrawLine(
                    graphicsDevice,
                    new Vector3(center - last, 0),
                    new Vector3(center - at, 0),
                    color,
                    effect,
                    world, view, projection);
                LineRenderer.DrawLine(
                    graphicsDevice,
                    new Vector3(center + lastP, 0),
                    new Vector3(center + atP, 0),
                    color,
                    effect,
                    world, view, projection);
                LineRenderer.DrawLine(
                    graphicsDevice,
                    new Vector3(center - lastP, 0),
                    new Vector3(center - atP, 0),
                    color,
                    effect,
                    world, view, projection);

                last = at;
                lastP = atP;
            }
        }

        private static Vector2 Perpendicular(Vector2 vector)
        {
            var (x, y) = vector;
            return new Vector2(-y, x);
        }

        private static Vector2 AngleToVector(float angleRadians, float length)
        {
            return new Vector2((float)Math.Cos(angleRadians) * length, (float)Math.Sin(angleRadians) * length);
        }
    }
}