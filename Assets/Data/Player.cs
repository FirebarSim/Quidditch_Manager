using System.Collections;
using System.Collections.Generic;

public class Player {
    public string name { get; protected set; }
    string sex;
    int age;
    float skillChaser;
    float skillBeater;
    float skillKeeper;
    float skillSeeker;

    public Player( string name, string sex, int age, float skillChaser, float skillBeater, float skillKeeper, float skillSeeker) {
        this.name = name;
        this.sex = sex;
        this.age = age;
        this.skillChaser = skillChaser;
        this.skillBeater = skillBeater;
        this.skillKeeper = skillKeeper;
        this.skillSeeker = skillSeeker;
    }
}
