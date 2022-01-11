using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DDZD
{
    public static class PrimitiveRenderer
    {
        public static void DrawCircleF(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Vector2 center,
            float radius,
            float resolution = 3f)
        {
            CircleRenderer.DrawCircleF(
                graphicsDevice,
                effect: effect,
                world: world, view: view, projection: projection,
                color: color,
                center: center,
                radius: radius,
                resolution: resolution
            );
        }

        public static void DrawCircleH(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Vector2 center,
            float radius,
            float resolution = 3f)
        {
            CircleRenderer.DrawCircleH(
                graphicsDevice,
                effect: effect,
                world: world, view: view, projection: projection,
                color: color,
                center: center,
                radius: radius,
                resolution: resolution
            );
        }

        public static void DrawTriangleF(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Vector2 center,
            float radius,
            float resolution = 3f)
        {
            CircleRenderer.DrawCircleF(
                graphicsDevice,
                effect: effect,
                world: world, view: view, projection: projection,
                color: color,
                center: center,
                radius: radius,
                resolution: resolution
            );
        }

        public static void DrawTriangleH(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Vector2 a, Vector2 b, Vector2 c)
        {
            TriangleRenderer.DrawTriangleF(
                graphicsDevice,
                effect: effect,
                world: world, view: view, projection: projection,
                color: color,
                a: a, b: b, c: c
            );
        }
    }
}