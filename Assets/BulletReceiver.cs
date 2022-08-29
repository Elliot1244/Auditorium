using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletReceiver : MonoBehaviour
{

    [SerializeField] int _bulletMax;       //Score max pour notre objectif
    [SerializeField] float _idleDuration;  //Dur�e d'attente avant de baisser le score
    [SerializeField] float _reductionSpeedInSecond; //Vitesse r�duction du score

    [Header("Sprite Renderer")]
    [SerializeField] SpriteRenderer[] _gauge;
    [SerializeField, ColorUsage(true, true)] Color  _onSprite;   //Couleur de l'�l�ment in gauge
    [SerializeField, ColorUsage(true, true)] Color _offSprite; //Couleur de l'�l�ment off gauge

    [Header("Audio")]
    [SerializeField] AudioSource _audio; //AudioSource

    [Header("Events")]
    [SerializeField] UnityEvent _onBulletReceived;
    [SerializeField] UnityEvent _onObjectifCompleted;
    [SerializeField] UnityEvent _onLevelFinished;

    float _currentScore; //Score actuel dans le jeu
    float _lastBulletReceived; //Date de r�ception de la derni�re bullet


    private void Start()
    {
        _currentScore = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        
        //Si une bullet rentre en contact
        BulletMouvement bullet = collision.GetComponentInParent<BulletMouvement>();
        if(bullet != null)
        {
            //M�thode 1
            //if (_currentScore < _bulletMax)
            //{
            //   _currentScore++;
            //}

            float _oldScore = _currentScore;
            //M�thode 2
            _currentScore = Mathf.Min(_currentScore + 1, _bulletMax);
            _lastBulletReceived = Time.time;
            Debug.Log($"Score actuel {_currentScore}");
            _onBulletReceived.Invoke();

            if(_currentScore < _bulletMax)
            {
                _onBulletReceived.Invoke();
            }
            else if(_oldScore < _bulletMax && _oldScore >= _bulletMax)
            {
                _onObjectifCompleted.Invoke();
            }
        }
    }

    private void Update()
    {
        // R�cup�ration date actuelle

        //Si la date actuelle d�passe la date de la derni�re Bullet + duration
        if(Time.time  > _lastBulletReceived + _idleDuration)
        {
            //Descente du score
            _currentScore = Mathf.Max(_currentScore - _reductionSpeedInSecond * Time.time, 0);
        }


        //Combien on a rempli notre objectif ?
        float percent = (float)_currentScore / (float)_bulletMax;
        //En prenant ce pourcentage, �a repr�sente combien de slot chez nous ?
        float gaugeCompletion = percent * _gauge.Length;



        //Mettre � jour le rendu de l'objectif
        for (int i = 0; i < _gauge.Length; i++)
        {
            if(i  < gaugeCompletion)
            {
                _gauge[i].color = _onSprite;
            }
            else
            {
                _gauge[i].color = _offSprite;
            }
        }
        _audio.volume = percent; 
    }

    public bool IsValidated()
    {
        if(_currentScore >= _bulletMax)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
