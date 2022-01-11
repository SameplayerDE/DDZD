using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DDZD
{
    public static class TriangleRenderer
    {
        private static VertexPositionColor[] _vertices;

        static TriangleRenderer()
        {
            _vertices = new VertexPositionColor[3];
        }

        public static void DrawTriangleF(
            GraphicsDevice graphicsDevice,
            Vector3 a, Vector3 b, Vector3 c,
            Color colorA, Color colorB, Color colorC,
            Effect effect,
            Matrix world, Matrix view, Matrix projection)
        {
            _vertices[0].Position = a;
            _vertices[0].Color = colorA;

            _vertices[1].Position = b;
            _vertices[1].Color = colorB;
            
            _vertices[2].Position = c;
            _vertices[2].Color = colorC;

            effect.Parameters["WorldViewProjection"]
                ?.SetValue(world * view * projection);
            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, _vertices, 0, 1);
            }
        }
        
        public static void DrawTriangleF(
            GraphicsDevice graphicsDevice,
            Vector3 a, Vector3 b, Vector3 c,
            Color color,
            Effect effect,
            Matrix world, Matrix view, Matrix projection)
        {
            DrawTriangleF(graphicsDevice, a, b, c, color, color, color, effect, world, view, projection);
        }
        
        public static void DrawTriangleF(
            GraphicsDevice graphicsDevice,
            Vector2 a, Vector2 b, Vector2 c,
            Color color,
            Effect effect,
            Matrix world, Matrix view, Matrix projection)
        {
            var a3 = new Vector3(a, 0);
            var b3 = new Vector3(a, 0);
            var c3 = new Vector3(a, 0);
            
            DrawTriangleF(graphicsDevice, a3, b3, c3, color, effect, world, view, projection);
        }
        
        public static void DrawTriangleF(
            GraphicsDevice graphicsDevice,
            Triangle triangle,
            Color color,
            Effect effect,
            Matrix world, Matrix view, Matrix projection)
        {
            var a = triangle.A;
            var b = triangle.B;
            var c = triangle.C;
            
            DrawTriangleF(graphicsDevice, a, b, c, color, effect, world, view, projection);
        }
    }

    public struct Triangle
    {
        public Vector2 A, B, C;
    }
}