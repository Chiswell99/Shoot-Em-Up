using UnityEngine;

public static class InputProvider
{
    public delegate void Direction(Vector3 direction);
    public static event Direction OnDirection;
    public delegate void HasShoot(); //Delegado para definir un nombre.
    public static event HasShoot OnHasShoot;//El evento OnHasShoot que es de ese tipo de delegado.
                                     //Esto nos ayuda para cuando otra clase tenga que responder a este evento sabe que tiene que venir
                                     //con lo que hasShoot tenga definido. Por ejemplo si tiene una serie de parametros, la clase que utilice este evento
                                     //debera tener esta firma.
    public static void TriggerOnHasShoot()
    {
        OnHasShoot?.Invoke();
    }

    public static void TriggerDirection(Vector3 direction)
    {
        OnDirection?.Invoke(direction);
    }
}
