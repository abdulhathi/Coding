using System.Text;

public class SimplifyPathToGetCanonical {
    public SimplifyPathToGetCanonical() {
        Console.WriteLine(SimplifyPath("///h.ome/.."));
    }
    public string SimplifyPath(string path) {
        int n = path.Length;
        StringBuilder sb = new StringBuilder();
        if(path[0] != '/')
            sb.Append("/");
        
        for(int i = n-1; i >= 0; i++) {
            if(i - 1 >= 0 && path[i-1] == '.' && path[i] == '.' && i+1 < n && path[i+1] != '.') {
                sb.Remove(sb.Length-1,1);
                continue;
            }
            if(i - 1 >= 0 && path[i-1] == '/' && path[i] == '/')
                continue;
            sb.Append(path[i]);
        }
        
        if(sb[sb.Length-1] == '/')
            sb.Remove(sb.Length-1,1);
        
        return sb.ToString();
    }
}