namespace toys.vote;

public class Candidate(CandidatesTypes type, string name, int number)
{
    public int Number { get; set; } = number;
    public required string Name { get; set; } = name;
    public required CandidatesTypes CandidateType { get; set; } = type;
}

public class President(string name, int number) : Candidate(CandidatesTypes.Presidente, name, number);
public class Deputy(string name, int number) : Candidate(CandidatesTypes.Deputado, name, number);


public enum CandidatesTypes
{
    Presidente,
    Deputado
}