using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public Tilemap tilemap;
    public float moveSpeed = 1f;

    private Vector3Int currentCell;
    private Vector3Int targetCell;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        currentCell = tilemap.WorldToCell(transform.position);
        targetCell = currentCell;
        targetPosition = transform.position;
    }

    void Update()
    {
        // Si el personaje no se está moviendo, revisa si el usuario presiona las teclas de flecha para moverse
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                targetCell.y += 1;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                targetCell.y -= 1;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                targetCell.x -= 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                targetCell.x += 1;
            }

            // Si el personaje tiene un objetivo de movimiento, establece la posición de destino y comienza el movimiento
            if (targetCell != currentCell)
            {
                isMoving = true;
                targetPosition = tilemap.GetCellCenterWorld(targetCell);
            }
        }

        // Si el personaje se está moviendo, mueve gradualmente al personaje hacia la posición de destino
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Si el personaje llega a la posición de destino, detiene el movimiento y actualiza la celda actual
            if (transform.position == targetPosition)
            {
                isMoving = false;
                currentCell = targetCell;
            }
        }

        // Actualiza la posición de la cámara para seguir al personaje
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }
}
