package model;

import java.util.ArrayList;

public class Config {
    private Integer id;
    private ArrayList<String> letters;
    private String firstWord;
    private String secondWord;
    private String thirdWord;

    public Config() {
    }

    public Config(Integer id, ArrayList<String> letters, String first, String second, String third){
        this.id = id;
        this.letters = letters;
        this.firstWord = first;
        this.secondWord = second;
        this.thirdWord = third;
    }

    public Integer getId() {
        return id;
    }
    public void setId(Integer id) {
        this.id = id;
    }

    public ArrayList<String> getLetters() {
        return letters;
    }
    public void setLetters(ArrayList<String> currentLetters) {
        this.letters = currentLetters;
    }

    public String getFirstWord() {
        return firstWord;
    }
    public void setFirstWord(String word) {
        this.firstWord = word;
    }

    public String getSecondWord() {
        return secondWord;
    }
    public void setSecondWord(String word) {
        this.secondWord = word;
    }

    public String getThirdWord() {
        return thirdWord;
    }
    public void setThirdWord(String word) {
        this.thirdWord = word;
    }

    @Override
    public String toString() {
        return "Config" +
                "ID=" + id + letters.toString() + " " + firstWord + " " + secondWord + " " + thirdWord;
    }

}
