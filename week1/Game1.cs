using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace week1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.SynchronizeWithVerticalRetrace = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
           
            InitColorVertices();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            DrawColorVertices();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        VertexPositionColor[] colorVertices;
        BasicEffect colorEffect;
        public void InitColorVertices()
        {
            colorEffect = new BasicEffect(GraphicsDevice);
            colorEffect.TextureEnabled = false;
            colorEffect.VertexColorEnabled = true;
            colorVertices = new VertexPositionColor[3];


            colorVertices[0].Position = new Vector3(1, -1, 0);
            colorVertices[0].Color = Color.Red;

            colorVertices[1].Position = new Vector3(-1, -1, 0);
            colorVertices[1].Color = Color.Green;

            colorVertices[2].Position = new Vector3(-1, 1, 0);
            colorVertices[2].Color = Color.Blue;
        }
        public void DrawColorVertices()
        {
            colorEffect.World = Matrix.Identity * Matrix.CreateTranslation(0, 0, -5);
            colorEffect.View = Matrix.CreateLookAt(new Vector3(0,0.01f,0),new Vector3(0,0,-1),Vector3.Up);

            colorEffect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(90), 1.77777f, 0.25f, 100f);
            colorEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, colorVertices, 0, colorVertices.Length / 3, VertexPositionColor.VertexDeclaration);
        }
    }
}
