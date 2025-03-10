using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; // O objeto que a câmera vai seguir (personagem)
    public float distance = 3.0f; // Distância da câmera para o personagem
    public float height = 1.5f; // Altura da câmera em relação ao personagem
    public float rotationSpeed = 100.0f; // Velocidade de rotação da câmera
    public float smoothSpeed = 0.125f; // Suavização do movimento da câmera

    private float currentRotation = 0.0f; // A rotação atual da câmera
    private float desiredRotation = 0.0f; // A rotação desejada (a rotação ao redor do personagem)

    void Update()
    {
        // Verifique se o jogador pressionou o botão para rotacionar a câmera (exemplo: botões de rotação)
        float inputX = Input.GetAxis("Mouse X");

        // Se houver movimento do mouse, rotacionamos a câmera
        desiredRotation += inputX * rotationSpeed * Time.deltaTime;

        // Aplicar a rotação desejada
        currentRotation = Mathf.LerpAngle(currentRotation, desiredRotation, Time.deltaTime * rotationSpeed);

        // Calcular a posição da câmera com base na rotação e distância
        Vector3 direction = new Vector3(0, height, -distance);
        Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);
        Vector3 desiredPosition = target.position + rotation * direction;

        // Suavizar a movimentação da câmera
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Fazer a câmera olhar para o personagem
        transform.LookAt(target);
    }
}
