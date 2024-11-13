using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{
    public int maxHearts = 3;             // Số trái tim tối đa của nhân vật
    public List<Image> heartImages;       // Danh sách hình ảnh trái tim
    public Sprite fullHeart;              // Hình ảnh trái tim đầy
    public Sprite emptyHeart;             // Hình ảnh trái tim rỗng

    private int currentHearts;

    void Start()
    {
        currentHearts = maxHearts;
        UpdateHeartsUI();                 // Cập nhật giao diện trái tim ban đầu
    }

    // Phương thức giảm số lượng máu và cập nhật giao diện
    public void TakeDamage(int damage)
    {
        currentHearts -= damage;
        if (currentHearts < 0)
            currentHearts = 0;            // Đảm bảo không âm

        UpdateHeartsUI();                 // Cập nhật giao diện trái tim
    }

    // Phương thức cập nhật giao diện trái tim
    void UpdateHeartsUI()
    {
        for (int i = 0; i < heartImages.Count; i++)
        {
            if (i < currentHearts)
                heartImages[i].sprite = fullHeart;  // Hiển thị trái tim đầy
            else
                heartImages[i].sprite = emptyHeart; // Hiển thị trái tim rỗng
        }
    }

    // Phương thức hồi máu nếu nhặt vật phẩm hồi máu
    public void Heal(int healAmount)
    {
        currentHearts += healAmount;
        if (currentHearts > maxHearts)
            currentHearts = maxHearts;    // Đảm bảo không vượt quá số lượng tối đa

        UpdateHeartsUI();                 // Cập nhật giao diện trái tim
    }
}