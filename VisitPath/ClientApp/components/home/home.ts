import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios'

class Edge
{
    vertexfrom:string;
    vertexTo:string;
    distance:number;
 
    /**
     * Build a new wdge giving the  vertex from the vertex to nd the distance between the vertices
     */
    constructor(vertexFrom:string, vertexTo:string, distance:number) {
        this.vertexfrom = vertexFrom;
        this.vertexTo = vertexTo;
        this.distance = distance;
    }
}

@Component
export default class CounterComponent extends Vue {
    vertices: string[] = [];
    edges: Edge[]= [];
    currentVertex: string = "";
    vertexFromSelected: string ="";
    vertexToSelected:string ="";
    distanceFromCurentVertex:number =0;
    fromVertex: string="";

    addVertex() {
        if(this.currentVertex != "")
            this.vertices.push(this.currentVertex);
    }

    addEdge(){
        if(this.vertexFromSelected != "" && this.vertexToSelected != "" && this.distanceFromCurentVertex !=0)
            this.edges.push(new Edge(this.vertexFromSelected, this.vertexToSelected,this.distanceFromCurentVertex));
    }

    getShortestPath(){
        if(this.fromVertex != "")
            axios.post("api/Graph/MinimumSpanningTree",{
                "InitialVertex": this.fromVertex,
                "Vertices":this.vertices,
                "Edges":this.edges
            }) .then(function (response) {
                console.log(response.data);
              })
              .catch(function (error) {
                console.log(error);
              });    
    }
}
