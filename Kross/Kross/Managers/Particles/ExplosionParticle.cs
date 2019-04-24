using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kross.Managers.Particles
{
    class ExplosionParticle
    {
        //Propriedades da particula
        public Vector3 posicao;
        public float velocidadeMedia;
        public float perturbacao;
        public Vector3 direcao;
        public float totalTimePassed;
        public Random random;

        //Array de vértices da particula
        public VertexPositionColor[] vertexes;

        public ExplosionParticle(Random random)
        {
            this.random = random;
            //Inicializar o array de vértices, sendo que cada particula tem dois vértices
            vertexes = new VertexPositionColor[2];
        }

        public void Update(Random random, GameTime gameTime)
        {
            //Atualizar a posição da particula
            posicao += direcao;
            totalTimePassed += (float)gameTime.ElapsedGameTime.Milliseconds;
            //Gravidade
            //posicao.Y -= totalTimePassed * totalTimePassed * velocidadeMedia * 7f;

            //Atualizar vértices
            vertexes[0].Position = posicao + direcao;
            vertexes[1].Position = (posicao + new Vector3(0, 0.05f, 0));

            direcao /= 1.01f;
        }

        public void Draw(GraphicsDevice graphics, BasicEffect efeito)
        {
            //World, View, Projection
            efeito.World = Matrix.Identity;
            efeito.View = Player.cameraView;
            efeito.Projection = Player.Projection();

            foreach (EffectPass pass in efeito.CurrentTechnique.Passes)
            {
                pass.Apply();

                //Desenhar as primitivas
                graphics.DrawUserPrimitives(PrimitiveType.LineList, vertexes, 0, 1);
            }
        }
    }
}
