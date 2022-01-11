using System.Drawing;
using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using Vector3 = Microsoft.Xna.Framework.Vector3;

namespace DDZD
{
    public static class LineRenderer
    {

        public static VertexPositionColor[] _vertices;

        static LineRenderer()
        {
            _vertices = new VertexPositionColor[2];
        }
    
    
        public static void DrawLine(
            GraphicsDevice graphicsDevice, 
            Vector3 a, Vector3 b,
            Color color, 
            Effect effect,
            Matrix world, Matrix view, Matrix projection)
        {
            DrawLine(graphicsDevice, a, b, color, color, effect, world, view, projection);
        }
        
        public static void DrawLine(
            GraphicsDevice graphicsDevice,
            Vector3 a, Vector3 b,
            Color colorA, Color colorB,
            Effect effect,
            Matrix world, Matrix view, Matrix projection)
        {
            _vertices[0].Position = a;
            _vertices[0].Color = colorA;
            
            _vertices[1].Position = b;
            _vertices[1].Color = colorB;
            
            effect.Parameters["WorldViewProjection"]
                ?.SetValue(world * view * projection);
            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawUserPrimitives(PrimitiveType.LineList, _vertices, 0, 1);
            }
        }
    }
}