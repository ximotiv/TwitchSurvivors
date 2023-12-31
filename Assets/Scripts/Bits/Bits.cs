using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(AudioSource))]
public class Bits : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private AudioSource _audio;

    private int _givesExperience = 2;
    private int _givesMoney = 2;

    public void Init()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _audio = GetComponent<AudioSource>();
    }

    public void UpdateData(Vector2 position, int givesExp, Sprite sprite)
    {
        transform.position = position;
        _givesExperience = givesExp;
        _givesMoney = givesExp;
        _sprite.sprite = sprite;

        Show();
    }

    public void Pickup(PlayerUnit player)
    {
        int exp = (int)PlayerData.CalculatePropertieValue(PlayerData.Properties.Fortune, _givesExperience);
        int money = (int)PlayerData.CalculatePropertieValue(PlayerData.Properties.Greed, _givesMoney);

        Money.Give(money);

        player.Experience.GiveExp(exp);
        player.PickupBits();

        _audio.Play();
        transform.DOScale(0, 0.2f);
        transform.DOMove(player.transform.position, 0.2f).OnComplete(()
            => Hide());
    }

    private void Show()
    {
        gameObject.SetActive(true);
        transform.DOScale(0.7f, 0.4f).SetEase(Ease.OutBack);
    }

    private void Hide()
    {
        //transform.DOScale(0, 0.2f).SetEase(Ease.InBack).OnComplete(() =>
            gameObject.SetActive(false);
    }
}
