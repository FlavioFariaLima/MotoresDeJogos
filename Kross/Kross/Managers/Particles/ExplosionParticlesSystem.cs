using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kross.Managers.Particles
{
    class ExplosionParticlesSystem
    {
        //Propriedades do sistema
        //Lista de particulas
        static List<ExplosionParticle> particulasVivas;
        static List<ExplosionParticle> particulasMortas;
        static List<ExplosionParticle> particulasRemover;
        static ExplosionParticle particula;

        static public int GetNParticulasVivas()
        {
            return particulasVivas.Count;
        }

        static public int GetNParticulasMortas()
        {
            return particulasMortas.Count;
        }

        static public void Initialize(Random random)
        {
            particulasVivas = new List<ExplosionParticle>(10000);
            particulasMortas = new List<ExplosionParticle>(10000);
            particulasRemover = new List<ExplosionParticle>(5000);

            for (int i = 0; i < 10000; i++)
            {
                particulasMortas.Add(new ExplosionParticle(random));
            }
        }

        static public void InserirExplosao(Vector3 posicao, int nParticulas, float velocidadeMedia, float perturbacao, Vector3 direcao)
        {
            if (particulasMortas.Count > 0)
            {
                for (int i = 0; i < nParticulas; i++)
                {
                    particula = particulasMortas.First();
                    particulasMortas.Remove(particula);
                    particula.totalTimePassed = 0;
                    particula.posicao = posicao;
                    particula.posicao.Y += 0.2f;
                    particula.velocidadeMedia = velocidadeMedia;
                    particula.perturbacao = perturbacao;
                    particula.direcao = direcao;


                    //Criar os vértices da particula
                    particula.vertexes[0].Position = posicao;
                    particula.vertexes[0].Color = Color.White;
                    particula.vertexes[1].Position = posicao - new Vector3(0, 0.01f, 0);
                    particula.vertexes[1].Color = Color.Red;

                    //Calcular a direção da particula
                    float angulo = (float)particula.random.NextDouble() * MathHelper.TwoPi;
                    particula.direcao.X = (float)particula.random.NextDouble() * (float)Math.Cos(angulo);
                    particula.direcao.Y = (float)particula.random.NextDouble() * (float)Math.Cos(angulo)
                        * (particula.random.Next(0, 4) >= 2 ? 1f : -1f);
                    particula.direcao.Z = (float)particula.random.NextDouble() * (float)Math.Sin(angulo);
                    particula.direcao.Normalize();
                    particula.direcao *= (float)particula.random.NextDouble() * velocidadeMedia + perturbacao;

                    particulasVivas.Add(particula);

                }
            }
        }

        static public void Update(Random random, GameTime gameTime)
        {
            //Atualizar as particulas deste sistema
            foreach (ExplosionParticle particula in particulasVivas)
            {
                particula.Update(random, gameTime);
            }

            //Verificar as particulas que devem morrer
            MatarParticulas();
        }

        static private void MatarParticulas()
        {
            particulasRemover.Clear();
            foreach (ExplosionParticle particula in particulasVivas)
            {
                if (particula.totalTimePassed > 3000)
                {
                    particulasRemover.Add(particula);
                }
            }
            foreach (ExplosionParticle particula in particulasRemover)
            {
                particulasVivas.Remove(particula);
                particulasMortas.Add(particula);
            }
        }

        static public void Draw(GraphicsDevice graphics, BasicEffect efeito)
        {
            //Desenhar as particulas deste sistema
            foreach (ExplosionParticle particula in particulasVivas)
            {
                particula.Draw(graphics, efeito);
            }
        }
    }
}
