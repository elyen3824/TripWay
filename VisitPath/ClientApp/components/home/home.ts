import Vue from 'vue';
import { Component } from 'vue-property-decorator';

class Edge
{
    from:Vertex;
    to:Vertex;
    weight:number;
 
    /**
     * Build a new wdge giving the  vertex from the vertex to nd the distance between the vertices
     */
    constructor(vertexFrom:string, vertexTo:string, distance:number) {
        this.from = new Vertex(vertexFrom);
        this.to = new Vertex(vertexTo);
        this.weight = distance;
    }
}

class Vertex {
    name: string;

    constructor(name:string) {
        this.name = name;
    }
}

class Data {
    start: string;
    edges: Edge[];
    vertices: Vertex[];
    graphName: string;

    constructor(name:string, vertices:Vertex[], edges:Edge[],start:string) {
        this.graphName = name;
        this.vertices = vertices;
        this.edges = edges;
        this.start = start;
    }
}

@Component
export default class CounterComponent extends Vue {
    vertices: Vertex[] = [];
    edges: Edge[]= [];
    currentVertex: string = "";
    vertexFromSelected: string ="";
    vertexToSelected:string ="";
    distanceFromCurentVertex:number =0;
    fromVertex: string="";
    visitPathName: string="";

    addVertex() {
        if(this.currentVertex != "")
            this.vertices.push(new Vertex(this.currentVertex));
    }

    addEdge(){
        if(this.vertexFromSelected != "" && this.vertexToSelected != "" && this.distanceFromCurentVertex !=0)
            this.edges.push(new Edge(this.vertexFromSelected, this.vertexToSelected,this.distanceFromCurentVertex));
    }

    getShortestPath(){
        if(this.fromVertex != "")
        {
            let data = new Data(this.visitPathName, this.vertices, this.edges, this.fromVertex);

            console.log(data);

            let fetchData = {
                method: "POST",
                body: JSON.stringify(data),
                headers:{
                    "Accept":"application/json",
                    "Content-Type":"application/json"
                }
            };

            console.log(fetchData);
            
            fetch('api/VisitPath/CalculateMinimumSpanningTree', fetchData)
                .then(response => response.json() as Promise<Edge[]>)
                .then(data => {
                    console.log(data);
                })
                .catch(error => {console.log(error)});
        }    
    }
}
