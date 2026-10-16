

## BlockedUsers

- Time complexity before: O(B * R)
- Time before => 250 ms

- What did you change?
  Replaced List.Contains() with HashSet.Contains() by creating a HashSet from the blocked IDs because This improves 
  performance from O(B) to O(1) on average reducing the overall time complexity from O(B * R) to O(B + R) on average 
  and number of blocked requests remains unchanged

- Time complexity after: O(B + R) on average
- Time after => 15 ms


## Students

- What was the problem?
  GetAllStudents() created and stored one million Student objects in a List even though Program.cs only printed the first three students
  This wasted execution time and memory 

- What did you change?
  Changed the return type from List<Student> to IEnumerable<Student> and used {yield return} to generate students on demand
  after this replacment when Program.cs stops after printing three students only three Student objects are created instead of one million