using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kross
{
    class SkyBox
    {

        Texture2D[] textures = new Texture2D[6];
        GraphicsDevice graphicsDevice;

        public Texture2D[] Textures
        {
            get { return textures; }
            set { textures = value; }
        }
        AlphaTestEffect _effect;

        VertexBuffer vertices;
        IndexBuffer indices;

        float YOffset = -(1000f / 2f);

        public SkyBox(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            LoadResources();
        }


        void LoadResources()
        {
            _effect = new AlphaTestEffect(this.graphicsDevice);

            vertices = new VertexBuffer(this.graphicsDevice,
                                typeof(VertexPositionTexture),
                                4 * 6,
                                BufferUsage.WriteOnly);

            VertexPositionTexture[] data = new VertexPositionTexture[4 * 6];

            float y = 0; //0.3f;

            #region Define Vertexes
            Vector3 vExtents = new Vector3(1000f, 1000f, 1000f);
            //back
            data[0].Position = new Vector3(vExtents.X, -vExtents.Y * y, -vExtents.Z);
            data[0].TextureCoordinate.X = 1.0f; data[0].TextureCoordinate.Y = 1.0f;
            data[1].Position = new Vector3(vExtents.X, vExtents.Y, -vExtents.Z);
            data[1].TextureCoordinate.X = 1.0f; data[1].TextureCoordinate.Y = 0.0f;
            data[2].Position = new Vector3(-vExtents.X, vExtents.Y, -vExtents.Z);
            data[2].TextureCoordinate.X = 0.0f; data[2].TextureCoordinate.Y = 0.0f;
            data[3].Position = new Vector3(-vExtents.X, -vExtents.Y * y, -vExtents.Z);
            data[3].TextureCoordinate.X = 0.0f; data[3].TextureCoordinate.Y = 1.0f;

            //front
            data[4].Position = new Vector3(-vExtents.X, -vExtents.Y * y, vExtents.Z);
            data[4].TextureCoordinate.X = 1.0f; data[4].TextureCoordinate.Y = 1.0f;
            data[5].Position = new Vector3(-vExtents.X, vExtents.Y, vExtents.Z);
            data[5].TextureCoordinate.X = 1.0f; data[5].TextureCoordinate.Y = 0.0f;
            data[6].Position = new Vector3(vExtents.X, vExtents.Y, vExtents.Z);
            data[6].TextureCoordinate.X = 0.0f; data[6].TextureCoordinate.Y = 0.0f;
            data[7].Position = new Vector3(vExtents.X, -vExtents.Y * y, vExtents.Z);
            data[7].TextureCoordinate.X = 0.0f; data[7].TextureCoordinate.Y = 1.0f;

            //bottom
            data[8].Position = new Vector3(-vExtents.X, -vExtents.Y * y, -vExtents.Z);
            data[8].TextureCoordinate.X = 0.0f; data[8].TextureCoordinate.Y = 0.0f;
            data[9].Position = new Vector3(-vExtents.X, -vExtents.Y * y, vExtents.Z);
            data[9].TextureCoordinate.X = 0.0f; data[9].TextureCoordinate.Y = 1.0f;
            data[10].Position = new Vector3(vExtents.X, -vExtents.Y * y, vExtents.Z);
            data[10].TextureCoordinate.X = 1.0f; data[10].TextureCoordinate.Y = 1.0f;
            data[11].Position = new Vector3(vExtents.X, -vExtents.Y * y, -vExtents.Z);
            data[11].TextureCoordinate.X = 1.0f; data[11].TextureCoordinate.Y = 0.0f;

            //top
            data[12].Position = new Vector3(vExtents.X, vExtents.Y, -vExtents.Z);
            data[12].TextureCoordinate.X = 1.0f; data[12].TextureCoordinate.Y = 1.0f;
            data[13].Position = new Vector3(vExtents.X, vExtents.Y, vExtents.Z);
            data[13].TextureCoordinate.X = 1.0f; data[13].TextureCoordinate.Y = 0.0f;
            data[14].Position = new Vector3(-vExtents.X, vExtents.Y, vExtents.Z);
            data[14].TextureCoordinate.X = 0.0f; data[14].TextureCoordinate.Y = 0.0f;
            data[15].Position = new Vector3(-vExtents.X, vExtents.Y, -vExtents.Z);
            data[15].TextureCoordinate.X = 0.0f; data[15].TextureCoordinate.Y = 1.0f;


            //left
            data[16].Position = new Vector3(-vExtents.X, vExtents.Y, -vExtents.Z);
            data[16].TextureCoordinate.X = 1.0f; data[16].TextureCoordinate.Y = 0.0f;
            data[17].Position = new Vector3(-vExtents.X, vExtents.Y, vExtents.Z);
            data[17].TextureCoordinate.X = 0.0f; data[17].TextureCoordinate.Y = 0.0f;
            data[18].Position = new Vector3(-vExtents.X, -vExtents.Y * y, vExtents.Z);
            data[18].TextureCoordinate.X = 0.0f; data[18].TextureCoordinate.Y = 1.0f;
            data[19].Position = new Vector3(-vExtents.X, -vExtents.Y * y, -vExtents.Z);
            data[19].TextureCoordinate.X = 1.0f; data[19].TextureCoordinate.Y = 1.0f;

            //right
            data[20].Position = new Vector3(vExtents.X, -vExtents.Y * y, -vExtents.Z);
            data[20].TextureCoordinate.X = 0.0f; data[20].TextureCoordinate.Y = 1.0f;
            data[21].Position = new Vector3(vExtents.X, -vExtents.Y * y, vExtents.Z);
            data[21].TextureCoordinate.X = 1.0f; data[21].TextureCoordinate.Y = 1.0f;
            data[22].Position = new Vector3(vExtents.X, vExtents.Y, vExtents.Z);
            data[22].TextureCoordinate.X = 1.0f; data[22].TextureCoordinate.Y = 0.0f;
            data[23].Position = new Vector3(vExtents.X, vExtents.Y, -vExtents.Z);
            data[23].TextureCoordinate.X = 0.0f; data[23].TextureCoordinate.Y = 0.0f;

            vertices.SetData<VertexPositionTexture>(data);


            indices = new IndexBuffer(graphicsDevice,
                                typeof(short), 6 * 6,
                                BufferUsage.WriteOnly);

            short[] ib = new short[6 * 6];

            for (int x = 0; x < 6; x++)
            {
                ib[x * 6 + 0] = (short)(x * 4 + 0);
                ib[x * 6 + 2] = (short)(x * 4 + 1);
                ib[x * 6 + 1] = (short)(x * 4 + 2);

                ib[x * 6 + 3] = (short)(x * 4 + 2);
                ib[x * 6 + 5] = (short)(x * 4 + 3);
                ib[x * 6 + 4] = (short)(x * 4 + 0);
            }

            indices.SetData<short>(ib);
            #endregion

        }

        public void Update(GameTime gameTime)
        {
            var pos = Player.WorldPosition().Translation;
            pos.Y += YOffset;
            _effect.World = Matrix.CreateTranslation(pos);
            _effect.Projection = Player.Projection();
            _effect.View = Player.cameraView;
        }


        public void Draw()
        {
            if (vertices == null)
                return;


            var ds = DepthStencilState.None;

            this.graphicsDevice.DepthStencilState = ds;
            this.graphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
            this.graphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
            this.graphicsDevice.SetVertexBuffer(vertices);
            this.graphicsDevice.Indices = indices;
            _effect.CurrentTechnique.Passes[0].Apply();

            for (int x = 0; x < 6; x++)
            {
                if (textures[x] == null) continue;

                _effect.Texture = textures[x];
                _effect.Techniques[0].Passes[0].Apply();
                graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, vertices.VertexCount, x * 6, 2);
            }

            this.graphicsDevice.DepthStencilState = DepthStencilState.Default;
        }
    }
}
