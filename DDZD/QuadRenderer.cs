using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DDZD
{
    public static class QuadRenderer
    {
        private static VertexPositionColor[] _vertices;
        private static short[] _indices;

        static QuadRenderer()
        {
            _vertices = new VertexPositionColor[4];
            _indices = new short[6];

            _indices = new short[]
            {
                0, 1, 2, 2, 1, 3
            };

        }

        public static void DrawQuadF(
            GraphicsDevice graphicsDevice,
            Vector3 a, Vector3 b, Vector3 c, Vector3 d,
            Color colorA, Color colorB, Color colorC, Color colorD,
            Effect effect,
            Matrix world, Matrix view, Matrix projection)
        {

            _vertices[0].Position = a;
            _vertices[0].Color = colorA;

            _vertices[1].Position = b;
            _vertices[1].Color = colorB;
            
            _vertices[2].Position = c;
            _vertices[2].Color = colorC;
            
            _vertices[3].Position = d;
            _vertices[3].Color = colorD;

            effect.Parameters["WorldViewProjection"]
                ?.SetValue(world * view * projection);
            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, _vertices, 0, 4, _indices, 0, 2);
            }
        }
        
        public static void DrawQuadF(
            GraphicsDevice graphicsDevice,
            Vector3 a, Vector3 b, Vector3 c, Vector3 d,
            Color color,
            Effect effect,
            Matrix world, Matrix view, Matrix projection)
        {
            DrawQuadF(graphicsDevice, a, b, c, d, color, color, color, color, effect, world, view, projection);
        }
        
        public static void DrawQuadF(
            GraphicsDevice graphicsDevice,
            Vector2 a, Vector2 b, Vector2 c, Vector2 d,
            Color color,
            Effect effect,
            Matrix world, Matrix view, Matrix projection)
        {
            var a3 = new Vector3(a, 0);
            var b3 = new Vector3(b, 0);
            var c3 = new Vector3(c, 0);
            var d3 = new Vector3(d, 0);

            DrawQuadF(graphicsDevice, a3, b3, c3, d3, color, effect, world, view, projection);
        }
        
        public static void DrawQuadF(
            GraphicsDevice graphicsDevice,
            Vector2 start, Vector2 end,
            Color color,
            Effect effect,
            Matrix world, Matrix view, Matrix projection)
        {
            var a = new Vector3(start, 0);
            var b = new Vector3(end.X, start.Y, 0);
            var c = new Vector3(start.X, end.Y, 0);
            var d = new Vector3(end, 0);

            DrawQuadF(graphicsDevice, a, b, c, d, color, effect, world, view, projection);
            
        }
        
        public static void DrawQuadF(
            GraphicsDevice graphicsDevice,
            Rectangle rectangle,
            Color color,
            Effect effect,
            Matrix world, Matrix view, Matrix projection)
        {
            var a = rectangle.Location.ToVector2();
            var b = a + rectangle.Size.ToVector2();
            
            DrawQuadF(graphicsDevice, a, b, color, effect, world, view, projection);
        }
        
    }
}