using System.Collections;
using System.Collections.Generic;

public class Manager {
    public string nameFirst { get; protected set; }
    public string nameLast { get; protected set; }
    // Coaching Skills
    public int coachingAttacking { get; protected set; }
    public int coachingDefending { get; protected set; }
    public int coachingFitness { get; protected set; }
    public int coachingKeeping { get; protected set; }
    public int coachingTactical { get; protected set; }
    public int coachingTechnical { get; protected set; }
    public int coachingMental { get; protected set; }
    public int coachingMentoring { get; protected set; }
    // Mental Skills
    public int mentalAdaptability { get; protected set; }
    public int mentalDetermination { get; protected set; }
    public int mentalDiscipline { get; protected set; }
    public int mentalManagement { get; protected set; }
    public int mentalMotivating { get; protected set; }
    public int mentalKnowledge { get; protected set; }

    public Manager( string nameFirst, string nameLast, int coachingAttacking, int coachingDefending, int coachingFitness, int coachingKeeping, int coachingTactical, int coachingTechnical, int coachingMental, int coachingMentoring, int mentalAdaptability, int mentalDetermination, int mentalDiscipline, int mentalManagement, int mentalMotivating, int mentalKnowledge ) {
        this.nameFirst = nameFirst;
        this.nameLast = nameLast;
        this.coachingAttacking = coachingAttacking;
        this.coachingDefending = coachingDefending;
        this.coachingFitness = coachingFitness;
        this.coachingKeeping = coachingKeeping;
        this.coachingTactical = coachingTactical;
        this.coachingTechnical = coachingTechnical;
        this.coachingMental = coachingMental;
        this.coachingMentoring = coachingMentoring;
        this.mentalAdaptability = mentalAdaptability;
        this.mentalDetermination = mentalDetermination;
        this.mentalDiscipline = mentalDiscipline;
        this.mentalManagement = mentalManagement;
        this.mentalMotivating = mentalMotivating;
        this.mentalKnowledge = mentalKnowledge;
    }
}
