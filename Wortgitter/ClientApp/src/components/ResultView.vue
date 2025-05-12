<template>
    <div>
        <canvas id="canvas" ></canvas>
    </div>
</template>

<script>
import { useStore } from '../stores/app.js';

export default {
    data() {
        return {
            resultData: {
                field: [
                    ['A', 'B', 'C'],
                    ['D', 'E', 'F'],
                    ['G', 'H', 'N']
                ],
                results: [['a1', 'a3'],['a2', 'c2'], ['a1', 'c3'], ['a3', 'c1']],
            }
        }
    },
    methods: {
        makeCanvas() {
            let canvas = document.getElementById('canvas');
            let ctx = canvas.getContext('2d');
            let canvasWidth = this.resultData.field[0].length;
            let canvasHeight = this.resultData.field.length;
            canvas.setAttribute('width', canvasWidth * 100);
            canvas.setAttribute('height', canvasHeight * 100);
            canvas.setAttribute('style', `height: ${canvasHeight * 100}px; width: ${canvasWidth * 100}px;`);

            //draw vertical lines
            for (let i = 0; i < canvasWidth + 1; i++) {
                let xValue = (canvasWidth * 100) / canvasWidth * (i); 
                this.drawLine(ctx, xValue, 0, xValue, canvasHeight * 100);
            }
            //draw horizontal lines
            for (let i = 0; i < canvasHeight + 1; i++) {
                let yValue = (canvasHeight * 100) / canvasHeight * (i);
                this.drawLine(ctx, 0, yValue, canvasWidth * 100, yValue);
            }
            //insert letters
            for (let i = 0; i < this.resultData.field.length; i++) {
                for (let j = 0; j < this.resultData.field[i].length; j++) {
                    let letter = this.resultData.field[i][j];
                    this.drawLetter(ctx, j * 100 + 25, (i + 1) * 100 - 25, letter);
                }
            }
            //encircle results
            for (let i = 0; i < this.resultData.results.length; i++) {
                let xValue1 = this.resultData.results[i][0].substring(0,1);
                xValue1 = xValue1.toUpperCase().charCodeAt(0) - 64;
                let yValue1 = parseInt(this.resultData.results[i][0].substring(1,2));
                let xValue2 = this.resultData.results[i][1].substring(0,1);
                xValue2 = xValue2.toUpperCase().charCodeAt(0) - 64;
                let yValue2 = parseInt(this.resultData.results[i][1].substring(1,2));
                ctx.strokeStyle = "red";
                ctx.lineWidth = 3;
                let pos1 = null;
                let pos2 = null;
                if (xValue1 == xValue2) { //vertical          
                    pos1 = [
                        (xValue1 - 1) * 100 + 10,
                        (yValue1 - 1) * 100 + 25,
                        xValue1 * 100 - 10,
                        (yValue1 - 1) * 100 + 25
                    ]
                    pos2 = [
                        (xValue2 - 1) * 100 + 10,
                        yValue2 * 100 - 25,
                        xValue2 * 100 - 10,
                        yValue2 * 100 - 25
                    ]
                    this.drawBendLine(ctx, 
                        pos1[0],
                        pos1[1],
                        xValue1 * 0.5 * 100,
                        (yValue1 - 1) * 100 + 5,
                        pos1[2],
                        pos1[3]
                    );
                    this.drawBendLine(ctx,
                        pos2[0],
                        pos2[1],
                        xValue2 * 0.5 * 100,
                        yValue2 * 100 - 5,
                        pos2[2],
                        pos2[3]
                    );
                } else if (yValue1 == yValue2) { //horizontal
                    pos1 = [
                        (xValue1 - 1) * 100 + 20,
                        yValue1 * 100 - 10,
                        (xValue1 - 1) * 100 + 20,
                        (yValue1 - 1) * 100 + 10
                    ]
                    pos2 = [
                        xValue2 * 100 - 20,
                        yValue2 * 100 - 10,
                        xValue2 * 100 - 20,
                        (yValue2 - 1) * 100 + 10
                    ]
                    this.drawBendLine(ctx,
                        pos1[0],
                        pos1[1],
                        (xValue1 - 1) * 100 + 5,
                        yValue1 * 100 - 50,
                        pos1[2],
                        pos1[3]
                    );
                    this.drawBendLine(ctx,
                        pos2[0],
                        pos2[1],
                        xValue2 * 100 - 5,
                        yValue2 * 100 - 50,
                        pos2[2],
                        pos2[3]
                    );
                }  else if (yValue1 < yValue2) { //top left -> bottom right
                    pos1 = [
                        (xValue1 - 1) * 100 + 10,
                        (yValue1 - 1) * 100 + 80,
                        (xValue1 - 1) * 100 + 80,
                        (yValue1 - 1) * 100 + 10
                    ]
                    pos2 = [
                        (xValue2 - 1) * 100 + 10,
                        (yValue2 - 1) * 100 + 80,
                        (xValue2 - 1) * 100 + 80,
                        (yValue2 - 1) * 100 + 10
                    ]
                    this.drawBendLine(ctx,
                        pos1[0],
                        pos1[1],
                        (xValue1 - 1) * 100,
                        (yValue1 - 1) * 100,
                        pos1[2],
                        pos1[3]
                    );
                    this.drawBendLine(ctx,
                        pos2[0],
                        pos2[1],
                        (xValue2 - 1) * 100 + 100,
                        (yValue2 - 1) * 100 + 100,
                        pos2[2],
                        pos2[3]
                    )
                } else { //bottom left -> bottom right
                    pos1 = [
                        (xValue1 - 1) * 100 + 90,
                        (yValue1 - 1) * 100 + 80,
                        (xValue1 - 1) * 100 + 10,
                        (yValue1 - 1) * 100 + 20                    
                    ]
                    pos2 = [
                        (xValue2 - 1) * 100 + 90,
                        (yValue2 - 1) * 100 + 80,
                        (xValue2 - 1) * 100 + 10,
                        (yValue2 - 1) * 100 + 20
                    ]
                    this.drawBendLine(ctx,
                        pos1[0],
                        pos1[1],
                        (xValue1 - 1) * 100,
                        (yValue1 - 1) * 100 + 100,
                        pos1[2],
                        pos1[3]
                    )
                    this.drawBendLine(ctx,
                        pos2[0],
                        pos2[1],
                        (xValue2 - 1) * 100 + 100,
                        (yValue2 - 1) * 100,
                        pos2[2],
                        pos2[3]
                    )
                }
                this.drawLine(ctx, pos1[0], pos1[1], pos2[0], pos2[1]);
                this.drawLine(ctx, pos1[2], pos1[3], pos2[2], pos2[3]);

            }
        },
        drawLine(ctx, originX, originY, targetX, targetY) {
            ctx.moveTo(originX, originY);
            ctx.lineTo(targetX, targetY);
            ctx.stroke()
        },
        drawBendLine(ctx, originX, originY, controlPointX, controlPointY, targetX, targetY) {
            ctx.beginPath();
            ctx.moveTo(originX, originY);
            ctx.quadraticCurveTo(controlPointX, controlPointY, targetX, targetY);
            ctx.stroke();  
        },
        drawLetter(ctx, positionX, positionY, letter) {
            ctx.font = "60px Arial";
            ctx.fillText(letter, positionX, positionY);
        },
    },
    mounted() {
        this.resultData = this.store.getResultData; 
        this.makeCanvas();
    }
}
</script>


