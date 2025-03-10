using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; // O objeto que a c�mera vai seguir (personagem)
    public float distance = 3.0f; // Dist�ncia da c�mera para o personagem
    public float height = 1.5f; // Altura da c�mera em rela��o ao personagem
    public float rotationSpeed = 100.0f; // Velocidade de rota��o da c�mera
    public float smoothSpeed = 0.125f; // Suaviza��o do movimento da c�mera

    private float currentRotation = 0.0f; // A rota��o atual da c�mera
    private float desiredRotation = 0.0f; // A rota��o desejada (a rota��o ao redor do personagem)

    void Update()
    {
        // Verifique se o jogador pressionou o bot�o para rotacionar a c�mera (exemplo: bot�es de rota��o)
        float inputX = Input.GetAxis("Mouse X");

        // Se houver movimento do mouse, rotacionamos a c�mera
        desiredRotation += inputX * rotationSpeed * Time.deltaTime;

        // Aplicar a rota��o desejada
        currentRotation = Mathf.LerpAngle(currentRotation, desiredRotation, Time.deltaTime * rotationSpeed);

        // Calcular a posi��o da c�mera com base na rota��o e dist�ncia
        Vector3 direction = new Vector3(0, height, -distance);
        Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);
        Vector3 desiredPosition = target.position + rotation * direction;

        // Suavizar a movimenta��o da c�mera
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Fazer a c�mera olhar para o personagem
        transform.LookAt(target);
    }
}
