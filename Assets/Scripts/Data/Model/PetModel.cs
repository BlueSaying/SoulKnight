public class PetModel : CharacterModel
{
    public new PetStaticAttr staticAttr { get => base.staticAttr as PetStaticAttr; set => base.staticAttr = value; }
    public new PetDynamicAttr dynamicAttr { get => base.dynamicAttr as PetDynamicAttr; set => base.dynamicAttr = value; }

    public PetModel(PetStaticAttr staticAttr, PetDynamicAttr dynamicAttr) : base(staticAttr, dynamicAttr) { }
}
