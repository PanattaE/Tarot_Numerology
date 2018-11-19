using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TarotReading : MonoBehaviour {

    Vector3 PastLoc;
    Vector3 PresentLoc;
    Vector3 FutureLoc;
    Quaternion q;
    Vector3 PastLocDefault;
    Vector3 PresentLocDefault;
    Vector3 FutureLocDefault;

    public int random;
    public int set = 0;
    public int cardFace = 0;
    public int cutValue;
    public GameObject Card;
    public GameObject PastReading;
    public GameObject PresentReading;
    public GameObject FutureReading;
    public Material[] CardFaces = new Material[78];
    public Text RNG;


    public GameObject[] CelticCrossSpread = new GameObject[10];
    public GameObject[] HorseshoeSpread = new GameObject[7];
    public GameObject[] HSButtons = new GameObject[7];
    public GameObject HSCard;

    public Text Past;
	public Text Present;
	public Text Future;

    public Text HSMeaning;

    public GameObject MainMenu;
    public GameObject TheCut;
    public GameObject TarotReads;
    public GameObject TR;

    public void OnMainMenuClick()
    {
        TarotReads.SetActive(false);
        TR.SetActive(false);
        MainMenu.SetActive(true);
        PastReading.transform.localPosition = new Vector3(0, 0, 0);
        PresentReading.transform.localPosition = new Vector3(0, 0, 0);
        FutureReading.transform.localPosition = new Vector3(0, 0, 0);
        PastReading.transform.rotation = q;
        PresentReading.transform.rotation = q;
        FutureReading.transform.rotation = q;
    }

    public void OnAnotherRead()
    {
        PastReading.transform.localPosition = new Vector3(0,0,0);
        PresentReading.transform.localPosition = new Vector3(0, 0, 0);
        FutureReading.transform.localPosition = new Vector3(0, 0, 0);
        PastReading.transform.rotation = q;
        PresentReading.transform.rotation = q;
        FutureReading.transform.rotation = q;
        Shuffle();
        TarotReads.SetActive(false);
        TheCut.SetActive(true);
    }

    public void OnHSCardOneClick()
    {
        HSButtons[0].SetActive(false);
        HSButtons[1].SetActive(true);
        HSCard.GetComponent<Renderer>().material = HorseshoeSpread[0].GetComponent<Renderer>().material;
        if (TarotDeck[0].Orientation % 2 == 1)
            HSMeaning.text = TarotDeck[0].UpsideDownMeaning;
        else
            HSMeaning.text = TarotDeck[0].UprightMeaning;
    }
    public void OnHSCardTwoClick()
    {
        HSButtons[1].SetActive(false);
        HSButtons[2].SetActive(true);
        HSCard.GetComponent<Renderer>().material = HorseshoeSpread[1].GetComponent<Renderer>().material;
        if (TarotDeck[1].Orientation % 2 == 1)
            HSMeaning.text = TarotDeck[1].UpsideDownMeaning;
        else
            HSMeaning.text = TarotDeck[1].UprightMeaning;

    }
    public void OnHSCardThreeClick()
    {
        HSButtons[2].SetActive(false);
        HSButtons[3].SetActive(true);
        HSCard.GetComponent<Renderer>().material = HorseshoeSpread[2].GetComponent<Renderer>().material;
        if (TarotDeck[2].Orientation % 2 == 1)
            HSMeaning.text = TarotDeck[2].UpsideDownMeaning;
        else
            HSMeaning.text = TarotDeck[2].UprightMeaning;
    }
    public void OnHSCardFourClick()
    {
        HSButtons[3].SetActive(false);
        HSButtons[4].SetActive(true);
        HSCard.GetComponent<Renderer>().material = HorseshoeSpread[3].GetComponent<Renderer>().material;
        if (TarotDeck[3].Orientation % 2 == 1)
            HSMeaning.text = TarotDeck[3].UpsideDownMeaning;
        else
            HSMeaning.text = TarotDeck[3].UprightMeaning;
    }
    public void OnHSCardFiveClick()
    {
        HSButtons[4].SetActive(false);
        HSButtons[5].SetActive(true);
        HSCard.GetComponent<Renderer>().material = HorseshoeSpread[4].GetComponent<Renderer>().material;
        if (TarotDeck[4].Orientation % 2 == 1)
            HSMeaning.text = TarotDeck[4].UpsideDownMeaning;
        else
            HSMeaning.text = TarotDeck[4].UprightMeaning;
    }
    public void OnHSCardSixClick()
    {
        HSButtons[5].SetActive(false);
        HSButtons[6].SetActive(true);
        HSCard.GetComponent<Renderer>().material = HorseshoeSpread[5].GetComponent<Renderer>().material;
        if (TarotDeck[5].Orientation % 2 == 1)
            HSMeaning.text = TarotDeck[5].UpsideDownMeaning;
        else
            HSMeaning.text = TarotDeck[5].UprightMeaning;
    }
    public void OnHSCardSevenClick()
    {
        HSButtons[6].SetActive(false);
        HSCard.GetComponent<Renderer>().material = HorseshoeSpread[6].GetComponent<Renderer>().material;
        if (TarotDeck[6].Orientation % 2 == 1)
            HSMeaning.text = TarotDeck[6].UpsideDownMeaning;
        else
            HSMeaning.text = TarotDeck[6].UprightMeaning;
    }
    public struct TarotCard
    {
        public string Name;
        public string UprightMeaning;
        public string UpsideDownMeaning;
        public int Orientation;
        public int Location;
    };
    TarotCard[,] MinorArcana = new TarotCard[4, 14];
    TarotCard[] MajorArcana = new TarotCard[22];
    TarotCard[] TarotDeck = new TarotCard[78];
    // Use this for initialization
    void Start () {
        q.SetEulerAngles(0, 0, 0);
        InitializeSwords();
        InitializePentacles();
        InitializeWands();
        InitializeCups();
        InitializeMajorArcana();
        //InitializeReading();
        initializeLocs();
        InitializeDeck();
        Shuffle();
        for (int i = 0; i <= 77; i++)
            Debug.Log(" Tarot Deck [" + i +"] is "+ TarotDeck[i].Name);
        //for (int l = 0; l < set; l++)
        //{
        //    Instantiate(MinorArcana[0,0].Cards);
        //}

    }
    void initializeLocs()
    {
        PastLoc = PastReading.transform.localPosition;
        PresentLoc = PresentReading.transform.localPosition;
        FutureLoc = FutureReading.transform.localPosition;



    }
    void InitializeReading()
    {
        PastReading = Card;
        PresentReading = Card;
        PresentReading = Card; 
    }
    void InitializeDeck()
    {
        for (int i = 0; i <= 3; i++)
        {
            for (int j = 0; j <= 13; j++)
            {
                TarotDeck[set] = MinorArcana[i, j];
                set++;
            }
        }
        for (int k = 0; k <= 21; k++)
        {
            TarotDeck[set] = MajorArcana[k];
            set++;
        }
    }
     void InitializeSwords()
    {
        MinorArcana[0, 0].Name = " Ace of Swords";
        MinorArcana[0, 0].UprightMeaning = "With its sharp blade and representing the power of the intellect, \n" +
            " this sword has the ability to cut through deception and find truth.\n" +
            " In layman's terms, this card represents that moment in which one can see the world from a new point of view, \n" +
            "as a place that is filled with nothing but new possibilities.\n " +
            " It is, therefore, the best time to work on your goals - as the aces all give green lights,\n" +
            " and are signals of waiting opportunities and new beginnings.\n";
        MinorArcana[0,0].UpsideDownMeaning = "This isn’t a good time for one to make any decisions since they don’t have any clarity on what you should be doing,\n " +
            "meaning that the chances of failure can be pretty high.\n" +
            "At this time, it would be better to prepare yourself and take baby steps - work methodically as you slowly move towards achieving your goals. \n" +
            "This would be a good time to lay back and rationally think your way through each stage rather than acting on impulse, \n" +
            "since everything appears in a blur and is not very clear at that moment. \n" +
            "It might also be a good time to seek advice since things may not be as they seem.\n";
        MinorArcana[0, 1].Name = " Two of Swords";
        MinorArcana[0, 1].UprightMeaning = ". Two equal and opposing forces are joined in battle, and there seems to be no end in sight.\n" +
            " This wasn't what you had in mind when you chanced to walk down this path, and you find yourself caught in the middle. \n" +
            "Without something, or someone to intervene, this may continue indefinitely. \n" +
            "We find ourselves in a situation where we must make a choice, we can side with one part of the situation, or we can side with the other. \n" +
            " Neither seems particularly appealing, which makes the decision even more difficult.\n " +
            "But unless we move past this stalemate, there can be no more progress.";
        MinorArcana[0, 1].UpsideDownMeaning = "The situation we see in the reversed Two of Swords is a stalemate of a legendary kind, one where two forces are battling each other.\n" +
            " This battle can be representative of both something internal or external, and you are forced to be in between and be the decision maker.\n" +
            " However, because neither party seems particularly pleasing to work with, you may find yourself confused, the pressure is too much,\n" +
            " and you are unable to make a decision.When you do make the decision, it will be choosing between two bad outcomes.\n" +
            " Do not worry, the more important thing here is to make a choice, \n" +
            "from then on, we can deal with whatever consequences come";
        MinorArcana[0, 2].Name = " Three of Swords";
        MinorArcana[0, 2].UprightMeaning = "The Three of Swords depicts the message of rejection, betrayal, hurt and discouragement. In moments like these, we are well served by the mind. If you can think logically about it and prepare for the experience, the impact of this pain may be minimized.";
        MinorArcana[0, 2].UpsideDownMeaning = "The Three of Swords reversed indicates that have faced a recent loss, a break-up or a moment of grief. You may be still recovering from this, and your emotions have not completely calmed, making it difficult to move on. Although you may still be thinking of your past suffering, this card may be a signal that it's time to let go and look forwards towards life ahead of you, because there is much for you to enjoy.";
        MinorArcana[0, 3].Name = " Four of Swords";
        MinorArcana[0, 3].UprightMeaning = "The Four of Swords is a moment of rest. Whether this is from a choice to withdraw, or whether it is from pure exhaustion, it is not clear. We are still tender from the wounds that were inflicted, and the battle weapons still hang above us as a grim reminder of what was lost. In order to continue and re-emerge in your daily life, you must take the time now to take a breather.";
        MinorArcana[0, 3].UpsideDownMeaning = "Although the Four of Swords card in a reading could mean it’s time for healing, a reversed card could mean restlessness. Your heart is willing to relax, but this is not what your mind wants. You feel that you have too much that is depending on you. Following this path is not advised, as it could have affects on your health.";
        MinorArcana[0, 4].Name = " Five of Swords";
        MinorArcana[0, 4].UprightMeaning = "This card indicates that you are engaging in a conflict of some nature. It can also suggest a disagreement with others, which leads to hostility and tension. Despite the fact that you think you’ve won, you might still lose in the big picture, because you have annoyed or hurt those that you have argued with, and as a result, you are on the road to isolating yourself.";
        MinorArcana[0, 4].UpsideDownMeaning = "The Five of Swords reversal meaning shows you that all you want is for that particular period to be over so that you can forget and forgive. Because you are beginning to understand that winning is not everything, you will be capable of focusing your energy on something a lot more constructive and positive";
        MinorArcana[0, 5].Name = " Six of Swords";
        MinorArcana[0, 5].UprightMeaning = "The meaning of the Six of Swords is that you are experiencing a transition of some kind, but one that is not happy and filled with regret. This transition will most likely be the result of decisions you made in the past, and now they are forcing you to leave something behind in order to move forward. Despite your sadness, you need to remember that moving on is the ideal option for your future";
        MinorArcana[0, 5].UpsideDownMeaning = "The Six of Swords reversed can indicate that you have been trying to move on and make the transitions you need. However, you may be experiencing challenges making these a reality. You may keep returning to the past, whether it's because there are issues that are not resolved, or you are questioning your decisions.";
        MinorArcana[0, 6].Name = " Seven of Swords";
        MinorArcana[0, 6].UprightMeaning = "There are instances when we are forced to be sneaky, hoping that we will not be discovered. When we are found out, we have to face the consequences - whether it's embarrassment, punishment, or worse. Sometimes this happens when there are instances when you had to think on your feet, and did something that was somewhat shrewd and out of character. Now there is a danger of the secret coming out.";
        MinorArcana[0, 6].UpsideDownMeaning = "You or someone in your circle may be deciding to unburden themselves with their guilt, and come clean about some piece of manipulation they have been involved in. Trust has been broken, but with a confession, you may be on the road to repairing it. There is a desire here to try and do things in a different way, one that is collaborative rather than independent.";
        MinorArcana[0, 7].Name = " Eight of Swords";
        MinorArcana[0, 7].UprightMeaning = "You may feel powerless because, in your mind, you feel that changing the situation might be beyond you. This feeling of helplessness that you have, the feeling that you have no agency in your life, has played a major role in making your situation worse.";
        MinorArcana[0, 7].UpsideDownMeaning = "One is capable of making conscious decisions because they are confident in who they are, and their power to affect change in both themselves and the world. It's time to free ones self from the past and proverbially clear out their closet, creating room for new things and experiences.";
        MinorArcana[0, 8].Name = " Nine of Swords";
        MinorArcana[0, 8].UprightMeaning = "There is a sense of repetition within this card, that some event which has troubled you before, and one which you managed to either repress or run away from, is coming back again. Sharing your grief does at least provide an outlet for your pain and may release you from carrying this burden alone. Is there anyone that you can feel comfortable speaking to?";
        MinorArcana[0, 8].UpsideDownMeaning = "You must understand that this suffering will not cease until you yourself put in the effort to leave it. There is much work that you must do to drag yourself towards release. But just as you have a ways out, you must understand that you can still fall deeper into despair. Your job is to avoid that outcome, if you push forward you may find yourself out, but if you do not, you may find yourself sinking deeper.";
        MinorArcana[0, 9].Name = " Ten of Swords";
        MinorArcana[0, 9].UprightMeaning = "It shows that a certain force of extreme magnitude has come to hit you in your life - one that you may have not foreseen. There is a sense of betrayal that is indicated here, for the character is stabbed in the back. This seems to be a reminder that despite how much we try, we cannot control everything - there are things that are beyond our ability to change. Here, this situation is unavoidable. ";
        MinorArcana[0, 9].UpsideDownMeaning = "With the reversal though, also comes to a recognition that you have hit rock bottom, there is no more that is left for you to give. With that also comes the release that things can only get better and the cycle can start anew. But like with the eight and nine of swords, this release must be initiated by you. There is an opportunity being presented here to correct what has hurt you, but you must make the effort to climb out yourself. What has happened was terrible, but everyone has a part in the responsibility.";
        MinorArcana[0, 10].Name = " Page of Swords";
        MinorArcana[0, 10].UprightMeaning = "This card may indicate that you are very eager to execute an idea that you have been having or a project that you cooked up just recently. You are quite passionate about it, and you cannot wait to share the progress with others. Compared to your passionate heart, time seems to be standing still. It is time to be talkative. When a Page of Swords appears in a reading, it signifies communication and sharing of ideas. Whether it is someone else’s ideas or yours, it is time to open up and talk about them as long as it is a constructive.";
        MinorArcana[0, 10].UpsideDownMeaning = "When the Page of Swords is reversed, all the negative characteristics of her come out - and she may become almost dangerous. Being gifted with a sharp and alert mind, she may be using it for deception and manipulation. The sword that she wields may be used to create pain, her natural gift for language turned to a weapon. She may lack the understanding or the maturity to understand the suffering that she causes, feeling the rush that one gets upon lashing out.";
        MinorArcana[0, 11].Name = " Knight of Swords";
        MinorArcana[0, 11].UprightMeaning = "When we are thoroughly obsessed by a certain idea and strongly wish to manifest it, we are oftentimes so blinded by the actual desire for its fulfillment that we fail to note the difficulties which we may come across, or the actions and consequences that it could bring. The Knight of Swords is a very powerful figure that is full of life as well as energy. This needs to be balanced with a proper and actual realization of compassion and responsibility.";
        MinorArcana[0, 11].UpsideDownMeaning = "Their thoughts are oftentimes scattered throughout without any actual organization or logic. They are most likely disorganized and unprepared for the things that they actually want to achieve. The Knight of Swords reversal meaning indicates that you still have a lot of miles to walk in order to get the valuable life experience that you need in order to overcome adversities along the way. This is something to consider.";
        MinorArcana[0, 12].Name = " Queen of Swords";
        MinorArcana[0, 12].UprightMeaning = "This card represents the importance of making judgments without relying on emotion alone. The Queen of Swords beckons you to look at all the facts before making a decision. This queen does have compassion, which is why she has her hand reaching outwards in offering, but she wants to connect to people using an understanding that is intellectual.";
        MinorArcana[0, 12].UpsideDownMeaning = "The Queen of Swords reversed meaning is that you may be thinking too much with your heart, and you are becoming too emotionally involved with your current situation. You have to start thinking more objectively, because your emotions could lead you astray. Take the time to look at the situation using various facts and use your head to create a clearer picture of what is really going on. Only then, can you decide what your next move should be.";
        MinorArcana[0, 13].Name = " King of Swords";
        MinorArcana[0, 13].UprightMeaning = "The King of Swords appearing in a reading suggests that you should remain objective in your current situation - you must establish truth by sticking to the facts. The King of Swords and his intellectual power implies that you will need to use your intellect to make your point known and attain your goals. Besides your experience and education, you should be sharp and observant, to see deeply into problems that come your way.";
        MinorArcana[0, 13].UpsideDownMeaning = "The King of Swords in reversed shows tyrannical, abusive and manipulative habits. It may indicate the misuse of one’s mental power, drive, and authority. This is an illustration of persuasion and manipulation, so as to fulfill selfish desires. ";
        for (int i = 0; i <= 13; i++)
        {
			MinorArcana[0, i].Location= cardFace;
            //MinorArcana[0, i].Cards.GetComponent<Renderer>().material = CardFaces[cardFace];
            cardFace ++;
        }
    }
    void InitializePentacles()
    {
        MinorArcana[1, 0].Name = " Ace of Pentacles";
        MinorArcana[1, 0].UprightMeaning = "Because the suit of pentacles is primarily concerned with all things material (not just financial, but also with the sensual), this reset could manifest itself as a new career, the undertaking of a new venture, or the start of putting more care into your health. Wherever this beginning takes place, the Ace of Pentacles assures that what is to come will bring great abundance and opportunity. ";
        MinorArcana[1, 0].UpsideDownMeaning = "When one gets a reversed Ace of Pentacles, it may mean that they are about to face hard financial times as well as a lot of elusive opportunities. At this time, you are being advised against taking large financial risks and to think all your choices through when you are given a deal. ";
        MinorArcana[1, 1].Name = " Two of Pentacles";
        MinorArcana[1, 1].UprightMeaning = "The balancing act depicted in the card suggests that there are two major factors that you are deeply concerned about. It is time for you to step back to have a better perspective of the situation. While you may initially think it will save you time, multi-tasking may just worsen the situation. Cut down on your tasks and concentrate on these two factors that are troubling you.";
        MinorArcana[1, 1].UpsideDownMeaning = "You need to take at least a short break to eliminate the stress. In case you are feeling that you can’t handle everything, you need to consider your own well-being and provide yourself with a time to breathe. In your work, the Two of Pentacles reversal can be a positive omen. Avoid committing to a lot of things since it will overwhelm you";
        MinorArcana[1, 2].Name = " Three of Pentacles";
        MinorArcana[1, 2].UprightMeaning = "You may struggle to accomplish your goals as an individual, but the Three of Pentacles also teaches people not ignore the talents of the others that surround you. You need the collaboration of others, with diverse viewpoints, experiences and expertise to accomplish something more than you could have ever dreamed of.";
        MinorArcana[1, 2].UpsideDownMeaning = "There is lack of team work; it shows that people are working against each other and undermining the project along the way. There seems to be too much competition between them - each person is trying to display superiority. This result to scarcity of resources - too many people are viewing their project partners as competitors.";
        MinorArcana[1, 3].Name = " Four of Pentacles";
        MinorArcana[1, 3].UprightMeaning = "The Four of Pentacles is also a card which shows that you are currently in a position in which you have solid investments and that you are financially stable. Because of your new-found wealth, you are being particularly conservative about money, and you are most definitely not inclined to gamble when it comes to any kind of financial matters.";
        MinorArcana[1, 3].UpsideDownMeaning = "Instead of being protective you become greedy, and you succumb to stinginess. You are haunted by certain fears of poverty which compels you to be nothing but materialistic. You are incredibly self-protective and defensive in terms of materialistic things, and you are not opening up to trust other people out of fear that they may be taking them away. ";
        MinorArcana[1, 4].Name = " Five of Pentacles";
        MinorArcana[1, 4].UprightMeaning = "The meaning of this card can be deep loneliness, illness, poverty or loss. Your status might take a turn for the worse in the near future. There is a chance that you will lose something significant, whether it is financial wealth or an important item. Deterioration of your health might be already ongoing or be very sudden.";
        MinorArcana[1, 4].UpsideDownMeaning = "When drawing this card, it can mean that the worst is now over, but don’t expect changes to happen overnight. It will take some time before you can recover, and find strength once again. This means you will be able to regain stability in terms of property, health, relationships, business, or finances. ";
        MinorArcana[1, 5].Name = " Six of Pentacles";
        MinorArcana[1, 5].UprightMeaning = "Like the main figure in the card, the amount of money that you bring in and your expenses are balanced well, and you are fortunate enough to not have any stress. You are also grateful for all that you own and can happily share your wealth with others. As you can tell from the imagery in the card, the Six of Pentacles can be about charity.";
        MinorArcana[1, 5].UpsideDownMeaning = "If you have loaned someone money, you should not be expecting your money to be paid back, or your favor to be returned in the future. You should be cautious about the people you are lending money to, especially if you are not financially stable. You could also have problems with spending and giving away more than you can really afford. ";
        MinorArcana[1, 6].Name = " Seven of Pentacles";
        MinorArcana[1, 6].UprightMeaning = "If you are looking to invest, the Seven of Pentacles suggests that you are ready to put in a lot of effort, time and work into whatever you want to achieve. It reaffirms you of your long-term vision and helps to show that you are not confined to seeing results in the short term only. It shows how much you value the investment because of the effort that you are willing to put in.";
        MinorArcana[1, 6].UpsideDownMeaning = "The Seven of Pentacles reversed means that your returns may be scattered for now. It could also mean that the rewards of your labor are not as significant as you thought. The advantage of this is that it shows that you know when to stop investing your time, money or energy in a particular project. You, therefore, need to reevaluate your choices, and figure out where you should put your resources. ";
        MinorArcana[1, 7].Name = " Eight of Pentacles";
        MinorArcana[1, 7].UprightMeaning = "The task that you need to accomplish can be personal or professional. No matter what type of task it is, do not be afraid to ask for help when things get overwhelming. The Eight of Pentacles refers to the efforts that you undertake. There is a possibility that there will be a lot of things that you need to address. Hard work is essential, but you still need to find a balance";
        MinorArcana[1, 7].UpsideDownMeaning = "you need to execute swiftly and with great care if you want to be happy and successful with this outcome. In terms of work, the Eight of Pentacles reversed refers to the importance of impressing your employer through your diligence, dedication and intelligence. Never avoid any task or responsibility in your work - or else this can damage your reputation.";
        MinorArcana[1, 8].Name = " Nine of Pentacles";
        MinorArcana[1, 8].UprightMeaning = "The difficulties that were faced in the earlier journey of the pentacles appear to be over. The Nine of Pentacles conveys not only joy, but also the feeling of security and freedom that material wealth can bring. Looking back, the querent can now celebrate the difficulties, the struggles, and the hard work that lined her path.";
        MinorArcana[1, 8].UpsideDownMeaning = "Take this as an opportunity for you to figure out what it is most important. The Nine of Pentacles reversed indicates a moment when one truly sees - perhaps for the first time, that we cannot depend completely on material wealth to bring happiness.";
        MinorArcana[1, 9].Name = " Ten of Pentacles";
        MinorArcana[1, 9].UprightMeaning = "Everything will work out well in the end - for you have always kept the long term picture in view, choosing to take no shortcuts. Your legacy is sure to stand for quite a long time to come. This is a relief, for the path to get here has been filled with setbacks and challenges, making this point of the journey even sweeter.";
        MinorArcana[1, 9].UpsideDownMeaning = "The faulty nature of an investment that you have put a lot of time and effort in. In general, this reversed card seems to signal that you are placing too many bets on your short-term success, while harming your long-term potential. Take a step back and evaluate whether your decisions right now will lead to more damage in the future.";
        MinorArcana[1, 10].Name = " Page of Pentacles";
        MinorArcana[1, 10].UprightMeaning = "Determination, focus and the ability to stick with a particular task no matter how boring it may seem. In terms of work, the Page of Pentacles may signify that there are a lot of tasks you are responsible for, but your time to complete them is much too limited. This is not the time to feel stressed and overwhelmed. Assistance will be there for you, you just have to ask for it. ";
        MinorArcana[1, 10].UpsideDownMeaning = "When the Page of Pentacles card appears reversed, it may point to your lack of focus. There is a possibility that you are being distracted with lots of things. Try to borrow the talents of this page and focus your mind before moving on the next thing.";
        MinorArcana[1, 11].Name = " Knight of Pentacles";
        MinorArcana[1, 11].UprightMeaning = "You are fully committed to your assignments and you make sure that you complete your work efficiently.You are absolutely loyal and do the best you can in order to make sure the job will be properly completed. Though your sense of duty is admirable, beware that it does not turn into perfectionism -which can manifest itself in every aspect of your life.";
        MinorArcana[1, 11].UpsideDownMeaning = "You may be a driven and ambitious person who struggles to carry the weight of your responsibilities - so much so that you sacrifice your social life. Perhaps you can try taking more risks, or spend more time with friends and loved ones. The Knight of Pentacles reversed is a strong indication that you need to change this way of living, lest you risk burnout and exhaustion.";
        MinorArcana[1, 12].Name = " Queen of Pentacles";
        MinorArcana[1, 12].UprightMeaning = "The Queen of Pentacles therefore represents a motherly figure who desires to help you maneuver your way and achieve your goals with a the helping of her common sense. She will not only show you love, but she will also show you the way forward whenever you seem to be stranded and confused";
        MinorArcana[1, 12].UpsideDownMeaning = " you have misplaced priorities, which may eventually be compromising to your future. You may find yourself distracted and unable to focus on your work and your long-term goals. You could also be busy working on projects without taking time to consult experienced people who can guide you away from mistakes. ";
        MinorArcana[1, 13].Name = " King of Pentacles";
        MinorArcana[1, 13].UprightMeaning = "Stay in control of our energy and our resources in pursuit of a larger goal. When it comes to work, the King of Pentacles may refer to a more established man who will pay a significant role in your career. This man can be wise and rational, but he may also be careless when passing judgment. He can be your biggest supporter, but be prepared to receive unsolicited and harsh criticism.";
        MinorArcana[1, 13].UpsideDownMeaning = "Your definition of success and happiness is only determined by outer appearances, and not by the true value that security and stability can bring to you. It is a time for you to cultivate an more wholistic attitude to the material world to find an authentic happiness. In terms of love, this card can mean that someone dear to you is currently facing issues due to matters concerning his or her career.";
        for (int i = 0; i <= 13; i++)
        {
			MinorArcana[1, i].Location = cardFace;
            //MinorArcana[1, i].Cards.GetComponent<Renderer>().material = CardFaces[cardFace];
            cardFace++;
        }
    }
    void InitializeWands()
    {
        MinorArcana[2, 0].Name = " Ace of Wands";
        MinorArcana[2, 0].UprightMeaning = "When you draw the Ace of Wands, it is an indicator that you should just go for it. Take the chance and pursue an idea that you have in mind. Take the first steps to start the creative project. The Ace of Wands calls out to you to follow your instincts. If you think that the project that you've been dreaming of is a good idea, and then just go ahead and do it.";
        MinorArcana[2, 0].UpsideDownMeaning = "The reversed Ace of Wands indicates trials and tribulations that you will face in the near future. You might not have any direction, which leads to being uninspired or unmotivated. At this point of your life, you might not know what you really want to do. You don’t know how to get out of the slump. ";
        MinorArcana[2, 1].Name = " Two of Wands";
        MinorArcana[2, 1].UprightMeaning = "The Two of Wands is a more mature version of the ace of wands, meaning that that this tarot card is all about planning and moving forward – progression. Look at it this way; you have already set out to achieve a particular task, which means you have turned an idea into a realistic plan. Such a plan will require fulfillment and therefore you have to progress from just having the plan to actually achieving what you set out for.";
        MinorArcana[2, 1].UpsideDownMeaning = "The Two of Wands reversed meaning suggests the need to set up long-term goals. Begin the process of setting up your goals by identifying what to you is important. Proceed by planning how you intend on achieving such goals.";
        MinorArcana[2, 2].Name = " Three of Wands";
        MinorArcana[2, 2].UprightMeaning = "The meaning of the Three of Wands hints that you are planning or going to plan for the future with more conviction. This could mean that everything around your plans is going smoothly, as you have taken the time to plan your future, and are taking steps to turn plans into action. It hints that you are perhaps creating a stable foundation for yourself.";
        MinorArcana[2, 2].UpsideDownMeaning = "The reversed Three of Wands indicates that you may have been embarking on personal journeys or developments, but you have not received the achievements that you were hoping for. This could be due to delays or road blocks. Despite all this, the card reminds you that all of your work has not been for nothing, but rather that it has helped you with your personal strength and fortitude.";
        MinorArcana[2, 3].Name = " Four of Wands";
        MinorArcana[2, 3].UprightMeaning = "The symbolism within the Four of Wands poses that this is the perfect time for you to get together with close people such as friends and family. This could be with or without any special occasion. Oftentimes the card is known to reflect a period of holidays when you are together with your friends and family for an extended period of time.";
        MinorArcana[2, 3].UpsideDownMeaning = " It’s highly likely that there is a lot of tension between the members of your family or other loved ones. If you have completed something that is important to you, you are expecting to share it with those that are closest to you, and to come home to a welcome celebration, but instead, you find a lack of support. This may leave you feeling rather uncertain when it comes to your own relationships as well as the things that you can and cannot depend on. ";
        MinorArcana[2, 4].Name = " Five of Wands";
        MinorArcana[2, 4].UprightMeaning = "From the image on the card, the symbolism in the Five of Wands suggests that there is form of conflict in one’s life. This may be an existing conflict or one that is brewing and may eventually blow up in one's face. It may also depict a problem in communication, for example in a situation where no one really wants to listen to the other - meaning that no agreement or understanding takes place. ";
        MinorArcana[2, 4].UpsideDownMeaning = "The Five of Wands reversed meaning can be that your natural method of dealing with disagreements is avoiding any kind of conflict by getting away from that place as fast as you can. Sometimes this can be regarded as a good thing, but other times, it may lead to a number of issues that are brewing up within you, for which you will have to address soon. ";
        MinorArcana[2, 5].Name = " Six of Wands";
        MinorArcana[2, 5].UprightMeaning = "The card is indicative that you have managed to harness the strengths and talents that you have within you in an attempt to bring a particularly successful outcome in your life. You have managed to properly get through the confusion which is brought by the card before this one – the Five of Wands, and managed to properly minimize distractions, thus successfully focusing on your goals and achieving them.";
        MinorArcana[2, 5].UpsideDownMeaning = "You might be feeling particularly negative about your entire self as if you have failed others as well as yourself. This is a symbol that means that you lack the confidence and drive that you need to achieve. You need the overall support as well as recognition of third parties in order to pick you up, to emotionally provide you with some much-needed strength. ";
        MinorArcana[2, 6].Name = " Seven of Wands";
        MinorArcana[2, 6].UprightMeaning = "The overall meaning of the Seven of Wands is to hold your ground, no matter what is challenging your position.You will need to defend this position and take a stand against those who are aiming to take your spot. There are setbacks during this time, but you need to keep fighting for your beliefs and confront those that may threaten or oppose you and your beliefs.";
        MinorArcana[2, 6].UpsideDownMeaning = "The Seven of Wands reversal meaning is that you could be feeling overwhelmed by all the responsibilities and challenges that you are facing. This can make it difficult to see the whole picture. You can also feel that you have to compete and compare yourself to other people, which leaves you feeling vulnerable and inadequate.";
        MinorArcana[2, 7].Name = " Eight of Wands";
        MinorArcana[2, 7].UprightMeaning = "The image depicted by the Eight of Wands means that the difficulties that were brought by the Seven of Wands are finally over. It signifies a strong level of energy which states that different aspects of your life will be trailblazing. Perhaps important news will be coming on your way, and you may experience a sudden, yet steady positive growth.";
        MinorArcana[2, 7].UpsideDownMeaning = "Just like the upward Eight of Wands, the Eight of Wands reversed meaning is generally associated with patience. There is a possibility that you are feeling frustrated about something. You might now see that what you set in motion earlier created the obstacles that you are discovering right now. It is time for you to understand that you cannot change the past. You must forgive yourself, and adapt your strategy.";
        MinorArcana[2, 8].Name = " Nine of Wands";
        MinorArcana[2, 8].UprightMeaning = "The Nine of Wands symbolizes one's life, which has undergone too many trials but through their determination and will, they were able to overcome them. These won battles are symbolized by the eight upright wands; however, there are still more trials that the person may face. This can be one major trial or challenge that they are supposed to face for them to reach their goals or be successful in their quest. ";
        MinorArcana[2, 8].UpsideDownMeaning = "The Nine of Wands reversed shows a person who may not be a risk taker; they may not want to make a long-term move or commitment since they are afraid that they may not be able to come out of it. They are mistrustful and hence have created a boundary between themselves and others which is turning to be their own personal prison. You may be afraid that you do not have enough resources to face some upcoming challenges, which is why you may be open to running away or avoiding it.";
        MinorArcana[2, 9].Name = " Ten of Wands";
        MinorArcana[2, 9].UprightMeaning = "This card shows that you have already completed the circle of struggle. After spending too many resources and lots of energy looking for success, you have finally overcome the obstacles. The sweat off your brow was worth it - your efforts have finally been rewarded. You may find yourself living in a world of abundance where poverty and suffering have no chance to intervene.";
        MinorArcana[2, 9].UpsideDownMeaning = "When the Ten of Wands card is reversed, it indicates that you are truly burdened by circumstances which are not necessary in your life. Look around and see what is bothering you that will not positively impact yourself even if you rectify it. Drop them all and be a free being that can think soberly and do things accurately. Anything that does not add value in your life is not worth your time, so let it go.";
        MinorArcana[2, 10].Name = " Page of Wands";
        MinorArcana[2, 10].UprightMeaning = "When you get the Page of Wands, it simply means something is within you, something that triggers you to make discoveries, indulge in investments or take the next advancement in life. You could be just about to take a move on a certain idea, but some conflicting messages keep coming to your mind, and you get discouraged.";
        MinorArcana[2, 10].UpsideDownMeaning = "With the Page of Wands reversed, it tends to emphasize the more negative character traits of the upright version. He tends to show up when your mind is filled with one great idea after another, and are unable to progress beyond the beginning planning stages. Perhaps you have started a project or a hobby expecting that it would grow to great levels and instead you end up nowhere.";
        MinorArcana[2, 11].Name = " Knight of Wands";
        MinorArcana[2, 11].UprightMeaning = "If you are starting a creative project, then you should do so with lots of energy and enthusiasm. However, you should balance it with realistic and well-rounded views. You should also have a plan that takes into account the consequences of your actions.";
        MinorArcana[2, 11].UpsideDownMeaning = "When you get a reversed Knight of Wands, it indicates frustrations and delays. You may feel angry and that you are not getting anywhere. A reversed Knight of Wands can translate to a loss of power. You may be trying to compensate for something that you don’t have total control over - this might lead to pessimism and loss of self-esteem.";
        MinorArcana[2, 12].Name = " Queen of Wands";
        MinorArcana[2, 12].UprightMeaning = "In the event that you are looking for a job, the appearance of this card may mean that a woman will play a major role in your career move. Generally speaking, in terms of your career, things are looking pretty good. The Queen of Wands in questions of love also sends a positive energy. For people who are searching for love, there is a possibility that you will find it soon.";
        MinorArcana[2, 12].UpsideDownMeaning = "There is someone who needs your help right now. In terms of work, there is a probability that you will encounter obstacles that will hamper your progress. Do not mind these obstacles and continue doing your job as you see fit. To see this card may also be a reminder to adhere to your rational side - to balance your sometimes chaotic energy with clear though, and you will be more successful.";
        MinorArcana[2, 13].Name = " King of Wands";
        MinorArcana[2, 13].UprightMeaning = "The meaning of the upright position of the King of Wands represents pure energy. Unlike the other wands cards in the deck however, this particular one is not focused on pure creativity. Instead, this king is actually way more likely to take an idea and to decisively implement it himself. The King of Wands is a natural born leader of people, and he is also extremely capable. Once the king sets for himself a certain aim or a goal, he is going to conveniently stick to it in order to ensure that it becomes a reality.";
        MinorArcana[2, 13].UpsideDownMeaning = "When reversed, the card depicts a personality which is prone to taking rash, impulsive and hasty decisions. This person could be pushy, overbearing as well as dominating at times. Even though he might rarely do this with a sense of malice or with an intention to make someone feel submissive, this is without a doubt a part of his character that one can be frustrated at";
        for (int i = 0; i <= 13; i++)
        {
			MinorArcana[2, i].Location = cardFace;
            //MinorArcana[2, i].Cards.GetComponent<Renderer>().material = CardFaces[cardFace];
            cardFace++;
        }
    }
    void InitializeCups()
    {
        MinorArcana[3, 0].Name = " Ace of Cups";
        MinorArcana[3, 0].UprightMeaning = "The release indicated by this card may either be spiritual or emotional, depending on what you are going through. The Ace of Cups may come to a reading after a long period of being lonely or enduring something that deeply hurt you emotionally, and it's appearance may be there to herald the turning over a new leaf";
        MinorArcana[3, 0].UpsideDownMeaning = "When the Ace of Cups is overturned, the image here is clearest - the waters pour out of the cup, it becomes empty, the gift of its waters are being wasted. Seeing the Ace of Cups upside down during your reading means you have been enduring emotional instability or pain for some time. There is a loss that is indicated here, and perhaps something that has meant much to you is no longer giving you the joy that it once had";
        MinorArcana[3, 1].Name = " Two of Cups";
        MinorArcana[3, 1].UprightMeaning = "To see the Two of Cups is an indication of a partnership that is built on the union of forces, a strong connection and a balanced and equal partnership. The exchange of cups suggest that each party's emotions are intertwined with the other's, and each participant's feelings have profound affects on the other. A strong pair is indicated here, the joy of two becoming one.";
        MinorArcana[3, 1].UpsideDownMeaning = "When reversed, the Two of Cups can mean that the balance that was once there is broken. This balance was an integral part of keeping the individuals together, but to break it is to create disconnection and discord. The negative energy of two forces is present, and instead of them joining or attracting, they seem to repel each other";
        MinorArcana[3, 2].Name = " Three of Cups";
        MinorArcana[3, 2].UprightMeaning = "";
        MinorArcana[3, 2].UpsideDownMeaning = "When the Three of Cups is reversed, it means that you may have no time to socialize or go out with friends. You may be too busy with school or work that you can’t spare some time to have fun. The Three of Cups reversed can also mean losing touch with some of your friends. As time passes, you may find that you are growing apart from one another. When we grow older, we must put in effort to make sure that our friendships are not neglected.";
        MinorArcana[3, 3].Name = " Four of Cups";
        MinorArcana[3, 3].UprightMeaning = "You may feel as if there is no solution or way forward in your situation. Life has become stagnant, and nothing seems to make you happy or passionate. You are feeling apathetic - regardless of what happens, whether the day is good or bad, none of it matters to you. The Four of Cups commands a self-evaluation of your attitude so that you can pull yourself out of this rut. The solution is likely right in front of you, the hand is offering you a way out, but you release yourself out of your mental stubbornness and deploy new approach.";
        MinorArcana[3, 3].UpsideDownMeaning = "The sudden awareness of the transient beauty of life may strike you now, while previously you may have been too deeply disconnected from yourself to see it. You are coming to the understanding that though life is not perfect, there is beauty in it, and joy comes from choosing to see this beauty. Embrace new ideas, new people and new places; because you never know where these adventures can take you. Many may miss these chances because they are too confined in their own beliefs and ambitions.";
        MinorArcana[3, 4].Name = " Five of Cups";
        MinorArcana[3, 4].UprightMeaning = "You are feeling unhappy that a certain situation hasn’t really turned out the way you have hoped it would. Instead of moving towards a more positive perspective, this card seems to say that you are dwelling in the past, inducing feelings of self-pity and regret. The water which is actually spilled from the cups shows that you might have missed an opportunity. It also shows that the problem is mostly emotional and not material or financial.";
        MinorArcana[3, 4].UpsideDownMeaning = "When the card is reversed, the Five of Cups shows a significant recovery from the regret as well as proper acceptance of your past. You are beginning to realize all of the implications of your actions, and you have finally come to appreciate the lessons which can be learned from that experience.";
        MinorArcana[3, 5].Name = " Six of Cups";
        MinorArcana[3, 5].UprightMeaning = "You're wanting to return to a happier time, whether it was when you were a child, teenager, or young adult. Many times, these memories are things of the past, which reflect the aspects of ourselves that have vanished. You may feel that remembering these times is the only way to feel happy";
        MinorArcana[3, 5].UpsideDownMeaning = "The Six of Cups reversed can mean that you are clinging to the past. You should explore your memories, but you should not allow yourself to remain there. While you may find it comforting to be in the security of home, you must also learn to forge your own path. The past should be used as a guide for the future. Learn to focus on the present, and truly be aware. ";
        MinorArcana[3, 6].Name = " Seven of Cups";
        MinorArcana[3, 6].UprightMeaning = "You should be careful of wishful thinking and be alert of the choices that you make. In one sense, the Seven of Cups indicates that you are a dreamer who is both excited and afraid of the things that you see in your unconscious. In another, the Seven of Cups is a reminder that although it is good to have dreams and wishes, it is even better to take action attaining those dreams.";
        MinorArcana[3, 6].UpsideDownMeaning = "The Seven of Cups reversal is somewhat similar to the upright, as they both indicate dreams, illusions and temptations, but seem to emphasize the more negative qualities of this card. Your views may be inclined towards fantasy, and not grounded in reality. It may imply that you are unclear about the things that you are searching for";
        MinorArcana[3, 7].Name = " Eight of Cups";
        MinorArcana[3, 7].UprightMeaning = "Just like a caterpillar has to die before transforming into a beautiful butterfly, we all need to transform ourselves in our lives from time to time. This is the case especially after being tired of living what was the day to day, and embarking on a journey that will help one have a deeper understanding about life in general.";
        MinorArcana[3, 7].UpsideDownMeaning = "Getting the reversed Eight of Cups can show that one is in a state of confusion about which path they are supposed to take. The confusion usually arises from not knowing what is best for you and in the end, drifting in a sea of uncertainty is going to be the resulting effect.";
        MinorArcana[3, 8].Name = " Nine of Cups";
        MinorArcana[3, 8].UprightMeaning = "You have struggled to find purpose and joy after loss, you have tasted the different things that life offers, and you have left comfort in order to find greater heights. Here, you have found them, and you are indulging yourself as you celebrate this new stage of your life.";
        MinorArcana[3, 8].UpsideDownMeaning = "Your path has been a hard one, and you've arrived at a period where you may have the appearance of fulfillment, but something else is missing. This may outwardly appear as smugness, and can indicate your desire to receive attention and recognition for all that you have achieved. But you personally still feel dissatisfaction in yourself - it seems as though your desires are never-ending, a black hole";
        MinorArcana[3, 9].Name = " Ten of Cups";
        MinorArcana[3, 9].UprightMeaning = "An idyllic state of comfort, harmony, peace and love which makes you feel like you are in paradise. This is where all your dreams, wants, needs and wishes have been fulfilled, and you feel a complete sense of satisfaction. Take a moment and breathe, look around you and be thankful for all your blessings. This card signifies something that so many of us are searching for.";
        MinorArcana[3, 9].UpsideDownMeaning = "When the Ten of Cups is reversed, the strong bonds that one forges with family and community are broken, or twisted. The Ten of Cups is truly the most 'happily ever after' card, but somehow this idealized image of domestic peace and comfort is broken, or was unrealistic all along. Instead of connections, you may find distance. Instead of coming together, you may be pulling apart.";
        MinorArcana[3, 10].Name = " Page of Cups";
        MinorArcana[3, 10].UprightMeaning = "When you are being faced by difficult situations, and you have stopped chasing your dreams, the Page of Cups seems to say that you that you should tackle the issue from a totally different perspective. It symbolizes persistence as this is the only way that you can make your dreams come true. Listen to your intuition, follow your calling, and believe everything is possible.";
        MinorArcana[3, 10].UpsideDownMeaning = "There are things or projects that you find interesting, but you seem to do them for other reasons than for the joy of it. You may be doing them for money, for fame, or something else. A reversed Page of Cups could indicate that you should remember the joy that your projects brought you in the first place to reclaim your imaginative spirit.";
        MinorArcana[3, 11].Name = " Knight of Cups";
        MinorArcana[3, 11].UprightMeaning = "The truth is that the Knight of Cups is the most feminine amongst all the Knight cards in the tarot. It's important to note though, that this doesn’t even slightly suggest that he is any less of a worthy knight. It implies that he is in proper touch with his emotions and his intuition, and that he uses them for his own well-being and during his many romance and seduction quests. He is usually quite attractive and charming to others, regardless of their gender. ";
        MinorArcana[3, 11].UpsideDownMeaning = "Reversed, the Knight of Cups means that you allow your emotions to control your life a lot more than you should. You might be overly jealous, emotional or moody. In fact, this could get up to the point of actual incapacity to take action, which is most definitely to be avoided. Jumping to conclusions too fast is characteristic of a reversed Knight of Cups, and making judgements without having the necessary information is very com";
        MinorArcana[3, 12].Name = " Queen of Cups";
        MinorArcana[3, 12].UprightMeaning = "The Queen of Cups acts as a mirror and reflects the depths present in others, so they see themselves in a new light. Most times, the Queen of Cups can also represent the trusted inner voice you have within you. She seems to say that you should take the time to focus on your emotional health before trying to help others. Self-love creates compassion. ";
        MinorArcana[3, 12].UpsideDownMeaning = "The Queen of Cups reversed means that you are not in sync with your emotions. You can also feel restricted in the expressing the way that you truly feel. Most times, bottling up your emotions can be very damaging and will lead to a boiling point in the near future. You may have high levels of stress that you are not able to cope with anymore.";
        MinorArcana[3, 13].Name = " King of Cups";
        MinorArcana[3, 13].UprightMeaning = "The King of Cups tends to be political and diplomatic, and this makes it possible to for him to balance the needs of others, and enhance the harmony among all parties involved. The King of Cups shows that you are sensitive as a leader and you are careful with the way others respond to your emotional needs. The King of Cups implies that you should remain mature when dealing with negative energy.";
        MinorArcana[3, 13].UpsideDownMeaning = "When the King of Cups falters, his usual ability to handle situations with compassion and wisdom are turned upside down. He is unable to balance the needs of all that seek his guidance, and while appearing kind to some, may be cold to others. His talent in navigating the emotions of others may be put to dubious uses, manipulating circumstances to fit his needs.";
        for (int i = 0; i <= 13; i++)
        {
			MinorArcana[3, i].Location = cardFace;
          //  MinorArcana[3, i].Cards.GetComponent<Renderer>().material = CardFaces[cardFace];
            cardFace++;
        }
    }
    void InitializeMajorArcana()
    {
        MajorArcana[0].Name = "The Fool";
        MajorArcana[0].UprightMeaning = "To see the The Fool generally means a beginning of a new journey, one where you will be filled with optimism and freedom from the usual constraints in life. When we meet him, he approaches each day as an adventure, in an almost childish way. He believes that anything can happen in life and there are many opportunities that are lying out there, in the world, waiting to be explored and developed.";
        MajorArcana[0].UpsideDownMeaning = "When you land on the reversed Fool in your reading, you can generally find his more negative characteristics being on display. It can mean that you are literally acting like a fool by disregarding the repercussions of your actions. Like the youth depicted in the card, you don't see how dangerous of a position you find yourself in. ";
        MajorArcana[1].Name = "The Magician";
        MajorArcana[1].UprightMeaning = "The Magician is the representation of pure willpower. With the power of the elements and the suits, he takes the potential innate in the fool and molds it into being with the power of desire. He is the connecting force between heaven and earth, for he understands the meaning behind the words ( as above so below) - that mind and world are only reflections of one another. Remember that you are powerful, create your inner world, and the outer will follow.";
        MajorArcana[1].UpsideDownMeaning = "When you obtain the Magician reversed, it might mean its time for you to implement some changes. While right side up, the Magician represents true power, the reversed Magician is a master of illusion. The magic that he performs is one of deception and trickery. You may be lured in by the showmanship of his arts, but behind that there may be an intention to manipulate for selfish gain";
        MajorArcana[2].Name = "The High Priestess";
        MajorArcana[2].UprightMeaning = "When the High Priestess shows up it can depict an archetype known as the divine feminine - the mysterious female that understands and holds the answers to the deep unknowns; religion, self, nature. She represents someone that is intuitive, and beginning to open to her or his spirituality. Meditation, prayer and new spiritual work is indicated. ";
        MajorArcana[2].UpsideDownMeaning = "It is time for you to meditate and try new approach, for at this moment, the rational approach will not work. Something has been telling you to follow your gut, but you may be ignoring the call. There is a lot of confusion around you, and your actions may feel contrary to what you know is right. You must never be afraid to ask questions of yourself that may illuminate a new path forward for you, one that is more authentic to your inner self and your individual values.";
        MajorArcana[3].Name = "The Empress";
        MajorArcana[3].UprightMeaning = "The Empress shows us how deeply we are embedded to our femininity. Femininity could be associated with fertility, expression, creativity and nurturing among many other aspects. It therefore calls you to connect with beauty and bring happiness to your life. Understand yourself and get in touch with your sensuality so that you can attract life circumstances to bring happiness and joy. She is a signal that be kind to yourself, to take care of yourself.";
        MajorArcana[3].UpsideDownMeaning = "The Empress reversed indicates that you have lost too much of your own willpower and strength because you have started placing too much effort and concern to other people’s affairs. While the Empress's nature is of showering her loved ones with attention and care, this can sometimes go overboard. You might be neglecting your own needs, or even smothering the ones you love with your well-intentioned actions. ";
        MajorArcana[4].Name = "The Emperor";
        MajorArcana[4].UprightMeaning = "It’s all about control when it comes to the Emperor, for this card means authority, regulation, organization and a fatherliness. The Emperor represents a strategic thinker who sets out plans that he must see through. He is a symbol of the masculine principle - the paternal figure in life that gives structure, creates rules and systems, and imparts knowledge. Where the Empress's desire for their kingdom is to create happiness, the emperor desires to foster honor and discipline";
        MajorArcana[4].UpsideDownMeaning = "The Emperor reversed is a sign of abused authoritative power. In your social life, it can manifest in the overreach of power from a father figure or a possessive partner. In career readings, it could be coming from a superior. It presents a man who wants to take control of your actions and makes you feel powerless.";
        MajorArcana[5].Name = "The Hierophant";
        MajorArcana[5].UprightMeaning = "To see the Hierophant in a reading is to embrace the conventional, for it suggests that you have a certain desire to actually follow a process which has been well established. It also suggests that you want to stay within certain conventional bounds of what could be considered an orthodox approach.";
        MajorArcana[5].UpsideDownMeaning = "When you see the Hierophant in reverse, it may mean that you are feeling particularly restricted and even constrained from too many structures and rules. As a result, you have lost quite a lot of control as well as flexibility in your life. You have a particularly strong will and desire to go ahead and regain control as well as to break free from the shackles of convention";
        MajorArcana[6].Name = "The Lovers";
        MajorArcana[6].UprightMeaning = "The primary meaning within the Lovers is harmony, attractiveness, and perfection in a relationship. Another meaning behind the lovers card is the concept of choice -a choice between things that are opposing and mutually exclusive.This could be a dilemma that you need to think about carefully and make the best decision for your situation";
        MajorArcana[6].UpsideDownMeaning = "The Lovers reversed can point to both inner and outer conflicts that you are dealing with. The disharmony can make daily life difficult and could be putting pressure on your relationships. You should take time to think about what you are punishing yourself for, so you can fix them or let them go";
        MajorArcana[7].Name = "The Chariot";
        MajorArcana[7].UprightMeaning = "The Chariot tarot card is all about overcoming challenges and gaining victory through maintaining control of your surroundings. This perfect control and confidence allows the charioteer to emerge victorious in any situation. The use of strength and willpower are critical in ensuring that you overcome the obstacles that lie in your path. ";
        MajorArcana[7].UpsideDownMeaning = "The reversed Chariot's appearance in a reading can help you become aware of both your aggression, and your lack of willpower. It may either be saying that you are lacking in focus, motivation or direction, or that you are being warped by your obsession with your goals";
        MajorArcana[8].Name = "Strength";
        MajorArcana[8].UprightMeaning = "When you get the Strength card in an upright manner during your tarot reading, then it shows that you have inner strength and fortitude during moments of danger and distress. It shows that you have the ability to remain calm and strong even when your life is going through immense struggle. It also shows that you are a compassionate person and you always have time for other people even if it's at your own expense.";
        MajorArcana[8].UpsideDownMeaning = "An upside down Strength card can mean that you are (or about to) experience an intense anger or fear in your life. You seem to be lacking the inner strength that this card normally represents, meaning you might be experiencing fear, and a lack of conviction and confidence in your own abilities.";
        MajorArcana[9].Name = "The Hermit";
        MajorArcana[9].UprightMeaning = "You are currently contemplating that you need to be alone. Never be afraid to take this chance to reflect, as it could help you clear your mind of all the clutter that comes with everyday life.The Hermit may also refer to your effort in taking action that is authentic and aligned with your true self.You are perhaps searching your inner soul for guidance on what is right, and where your next steps are to be.";
        MajorArcana[9].UpsideDownMeaning = "When reversed, you are perhaps in a situation where you'd like to be alone; there is nothing wrong about that. However, there is a possibility that your seclusion may become harmful to both yourself and others. Though the Hermit sets forwards with noble intentions to search for his inner truth, his path inward may also be filled with great danger. Going inward may lead to madness and the abyss, for the unconscious is filled with images that he may not yet understand, lurking and waiting to lure you ever inside. ";
        MajorArcana[10].Name = "Wheel Of Fortune";
        MajorArcana[10].UprightMeaning = "The Wheel of Fortune turns evermore, seemingly to communicate that life is made up of both good and bad times, and that the cycle is one that we cannot control. It is something that is subjected to both kings and workers, and that nobody on earth can avoid what is fated. When you have good moments in your life, make sure that you enjoy to the fullest, for what comes up must always go down. The same is true in reverse - when you are in a bad situation, things will eventually become better again. ";
        MajorArcana[10].UpsideDownMeaning = "When the wheel is reversed, it means that luck has not been on your side and misfortunes have been following you. When it's associated with this card, you must understand that these are due to external influences that you cannot control. Like the wheel, our luck and our fate is always in motion, and sometimes we are on the bottom. Be assured that the wheel will turn again, and you will be okay again soon. ";
        MajorArcana[11].Name = "Justice";
        MajorArcana[11].UprightMeaning = "The decisions that you make now have long-term effects in all things, both for yourself and others. There will always come a time where you will be judged. The Justice tarot card appearing in a reading signals that a judgment will be made fairly and accordingly. The decisions that you have made in the past will be carefully weighed with fairness. Your feelings around this card may differ depending on your situation";
        MajorArcana[11].UpsideDownMeaning = "A reversed Justice tarot card could indicate various things. One Justice reversal meaning is to show you are living in denial. You are not willing to accept the consequences of your actions or others. You are running from your guilt. You must however, be aware that these are actions that are in the past. Your future depends on your actions today - and what you will do to tip the scales in balance again. ";
        MajorArcana[12].Name = "The Hanged Man";
        MajorArcana[12].UprightMeaning = "The Hanged Man card reflects a particular need to suspend certain action. As a result, this might indicate a certain period of indecision. This means that certain actions or decisions which need to be properly implemented are likely to be postponed even if there is an urgency to act at this particular moment. In fact, it would be ultimately the best if you are capable of stalling certain actions in order to ensure that you have more time to reflect on making critical decisions, this will ultimately be the best";
        MajorArcana[12].UpsideDownMeaning = "The reversal meaning of the Hanged Man card represents a very specific period of time during which you feel as if you are sacrificing a significant amount of time while getting nothing in return. You might have felt as if certain things are at a state of an absolute standstill without any particular resolution or movement. It’s as if you are putting your entire effort and attention into something but nothing turns out as it should. ";
        MajorArcana[13].Name = "Death";
        MajorArcana[13].UprightMeaning = "The Death card signals that one major phase in your life is ending, and a new one is going to start. You just need to close one door, so the new one will open. The past needs to be placed behind you, so you can focus your energy on what is ahead of you.";
        MajorArcana[13].UpsideDownMeaning = "The Death reversal meaning is still about change, but that you have been resisting it. You could be worried about letting go of the past, or you could not be sure of the changes that you need to make to go forward. Resisting the change and holding onto the past can limit your future, which can cause you to feel like you are in limbo.";
        MajorArcana[14].Name = "Temperance";
        MajorArcana[14].UprightMeaning = "In moments where there is anxiety or great stress, you have been able to remain calm throughout. You are a person who has mastered the art of not letting things get to you, and this allows you to achieve much progress in all areas you seek out to explore. The Temperance tarot card suggests moderation and balance, coupled with a lot of patience. ";
        MajorArcana[14].UpsideDownMeaning = "Temperance in reversed is a reflection of something that is out of balance and may be causing stress and anxiety. The real meaning of the Temperance card can be deciphered using the other cards in the spread to identify areas where this imbalance is being caused. A Temperance in reversal may also be used as a warning;  if you take a certain path, it would lead to turbulence and excess.";
        MajorArcana[15].Name = "The Devil";
        MajorArcana[15].UprightMeaning = "Getting the devil card in your reading shows that you have feelings of entrapment, emptiness and lack of fulfillment in your life. It might also mean that you are a slave to materialism and opulence and no matter how hard you try, you just can’t seem to shake off the feeling of wanting to indulge in luxurious living. ";
        MajorArcana[15].UpsideDownMeaning = "The upside down meaning of the Devil card can be the moment when an individual becomes self-aware and breaks all of the chains that come with addiction and poor habits. It might be because they are tired of running in circles and are in need of change. ";
        MajorArcana[16].Name = "The Tower";
        MajorArcana[16].UprightMeaning = "The Tower represents change in the most radical and momentous sense. It is for this reason that the card itself visually looks so unnerving. But it doesn't necessarily have to be truly frightening or ominous. Because at the heart of this card, its message is foundational, groundbreaking change.";
        MajorArcana[16].UpsideDownMeaning = "When you get the Tower card reversed, you can feel some crisis looming along the horizon, and you are struggling as much as you can to try and avoid its manifestation. What you have not realized is that these breakdowns can be beneficial in breaking down your reliance on something that is false. The tower is built on faulty foundations, and it must fall. Though the destruction will be painful, the humbleness resulting from it can bring us peace";
        MajorArcana[17].Name = "The Star";
        MajorArcana[17].UprightMeaning = "The Star brings hope, renewed power, and strength to carry on with life. It shows how abundantly blessed you are by the universe as evidenced by the various things around you. It may not be directly evident at the moment, for this card follows the trauma of the Tower card. Remember that you hold within you all that you need for your fulfillment - the only thing that you need is courage. For this, you have all reasons to rejoice. To see this card is a message to have faith, for the universe will bless you and bring forth all that you need.";
        MajorArcana[17].UpsideDownMeaning = "Without hope, without faith, we cannot find the motivation to progress forward in the challenges that we face. Where in your life are you feeling hopeless? In what ways do you already feel defeated? And how does that affect your actions? The star reversed asks us to nurture our sense of hope and positive energy to help propel our actions with joy instead of fear.";
        MajorArcana[18].Name = "The Moon";
        MajorArcana[18].UprightMeaning = "You need to be aware of the situations that are causing fear and anxiety in your mind, whether it is now or in the future. It alerts you not to allow inner disturbances and self-deception to take the best of you. These deep memories and fears must be let go, and the negative energies must be released and turned into something constructive.";
        MajorArcana[18].UpsideDownMeaning = "A Moon reversal in a reading can sometimes indicate that the darker and more negative aspects of the moon are present in your life. It could represent confusion and unhappiness - you want to make progress, but you are not sure what is the right thing to do. You must deal with your anxiety and fears by overcoming them, for they are like shadows in the dark. It is time to believe in yourself and move forward.";
        MajorArcana[19].Name = "The Sun";
        MajorArcana[19].UprightMeaning = "Because of your own personal fulfillment, you provide others with inspiration and joy as well. People are drawn to you because they are capable of seeing the warm and beautiful energy which you bring into their lives. You are also in a position in which you are capable of sharing your qualities as well as achievements with other people. You radiate love and affection towards those you care about the most.";
        MajorArcana[19].UpsideDownMeaning = "In the reversed position, the Sun indicates that you might have significant difficulties finding positive aspects to certain situations. The clouds might be blocking out the warmth and light that you need to progress. This might be preventing you from feeling confident and powerful. You may experience certain setbacks which are damaging your optimism and enthusiasm. ";
        MajorArcana[20].Name = "Judgement";
        MajorArcana[20].UprightMeaning = "The traditional Judgement meaning focuses on the moment when we reflect and evaluate ourselves and our actions. It is through self-reflection that we can have a clearer and objective understanding about where we are now, and what we need to do in order to grow as humans. The Judgement card appearing in a reading signifies that you are coming close to this significant point in your life where you must start to evaluate yourself.";
        MajorArcana[20].UpsideDownMeaning = "The reversed Judgement card can mean that you doubt and judge yourself too harshly. This could be causing you to miss opportunities that were awaiting you. The lost momentum causes you to fall behind in your plans, which can make it difficult to move forward. This means that you should not be cautious, but you should be moving forward with pride and confidence. ";
        MajorArcana[21].Name = "The World";
        MajorArcana[21].UprightMeaning = "To encounter the World in your cards is to encounter a great unity and wholeness. It symbolizes the moment when the inner and the outer worlds - self and other - become a single entity. In some traditions, this state is described as enlightenment, or nirvana. There is a recognition that the individual self is profoundly linked with all other things, and that we all dance and sway along the flow of life to one rhythm. Not only do you hear this rhythm, but you participate in it - following the dips and the rises, the joys and the sorrows. ";
        MajorArcana[21].UpsideDownMeaning = "You are drawing near to something that marks the end of a journey or an era. You may have many accomplishments that have lined your path, but there is a strange emptiness that fills you when you look backwards upon it, as if you have all the pieces but they are not coming together. What is missing? Do you feel connected to what you're doing? Do you feel connected to others? What alienates you from feeling complete? From feeling whole?";
        for (int i = 0; i <= 21; i++)
        {
			MajorArcana[i].Location = cardFace;
            cardFace++;
        }
    }
    void Shuffle()
    {
        int randomA;
         int randomB;
        TarotCard Temp;
        for (int i=0; i<78;i++)
        {
            randomA = Random.Range(0, 78);
            randomB = Random.Range(0, 78);
            Temp = TarotDeck[randomA];
            TarotDeck[randomA] = TarotDeck[randomB];
            TarotDeck[randomB] = Temp;
        }
    }
    public void Cut()
    {
        TarotCard temp;
        int Deck = 77 - cutValue;
        for (int i=0; i <= Deck ;i++)
        {
            temp = TarotDeck[i];
            TarotDeck[i] = TarotDeck[77 - i];
            TarotDeck[77 - i] = temp; 
        }

        Debug.Log("Button Click");
		TarotReads.SetActive(true);
        TheCut.SetActive(false);
        ReadAndWeep();
        CelticCrossRead();
        HorseshoeRead();
		}

    void ReadAndWeep()
    {
        Past.text = TarotDeck[0].UprightMeaning;
        Present.text = TarotDeck[1].UprightMeaning;
        Future.text = TarotDeck[2].UprightMeaning;
        for (int i = 0; i < 13; i++)
        {
            TarotDeck[i].Orientation = (Random.Range(0, 2));

        }
        if (TarotDeck[0].Orientation%2 == 1)
        {
            PastLoc.y = 11;
            PastReading.transform.localPosition = PastLoc;
            PastReading.transform.Rotate(0, 0, 180);
            Past.text = TarotDeck[0].UpsideDownMeaning;

        }
        if (TarotDeck[1].Orientation%2 == 1)
        {
            PresentLoc.y = 11;
            PresentReading.transform.localPosition = PresentLoc;
            PresentReading.transform.Rotate(0, 0, 180);
            Present.text = TarotDeck[1].UpsideDownMeaning;
        }
        if (TarotDeck[2].Orientation%2 == 1)
        {
            FutureLoc.y = 11;
            FutureReading.transform.localPosition = FutureLoc;
            FutureReading.transform.Rotate(0, 0, 180);
            Future.text = TarotDeck[2].UpsideDownMeaning;
        }

        PastReading.GetComponent<Renderer>().material = CardFaces[(TarotDeck[0].Location)];
        PresentReading.GetComponent<Renderer>().material = CardFaces[(TarotDeck[1].Location)];
        FutureReading.GetComponent<Renderer>().material = CardFaces[(TarotDeck[2].Location)];

    }
    // Update is called once per frame
    void CelticCrossRead()
    {
        for (int i = 0; i < 10; i++)
        {
            CelticCrossSpread[i].GetComponent<Renderer>().material = CardFaces[(TarotDeck[i].Location)];
        }
    }

    void HorseshoeRead()
    {
        for (int i = 0; i < 10; i++)
        {
            HorseshoeSpread[i].GetComponent<Renderer>().material = CardFaces[(TarotDeck[i].Location)];
        }
    }
    void Update () {
        cutValue = (Random.Range(0, 78));
        RNG.text = (""+cutValue+"");
		
	}
}
