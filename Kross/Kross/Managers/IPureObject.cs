using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kross.Managers
{
    public interface IPureObject
    {
        Matrix PositionMatrix();

        void SetActive(bool isActive);
        bool IsActive();

        void SetOnGround(bool onGround);

        BoundingSphere Collider();

        void SetInFrustumView(bool inView);

        void SetModel(Model model);
        void DrawModel();

        void Update(GameTime gameTime);
    }
}
