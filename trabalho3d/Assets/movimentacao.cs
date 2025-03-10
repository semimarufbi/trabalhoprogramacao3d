using UnityEngine;

public class movimentacao : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // Velocidade de movimento do personagem
    public float rotateSpeed = 700.0f;  // Velocidade de rotação do personagem

    private Rigidbody rb;

    void Start()
    {
        // Pega o Rigidbody do personagem
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Captura a entrada do jogador (WASD ou setas direcionais)
        float moveHorizontal = Input.GetAxis("Horizontal");  // A/D ou seta direita/esquerda
        float moveVertical = Input.GetAxis("Vertical");  // W/S ou seta cima/baixo

        // Move o personagem para frente e para os lados
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized * moveSpeed * Time.deltaTime;

        // Aplica o movimento
        rb.MovePosition(transform.position + movement);

        // Rota o personagem para a direção do movimento
        if (movement.magnitude > 0) // Só rotaciona se o personagem estiver se movendo
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
