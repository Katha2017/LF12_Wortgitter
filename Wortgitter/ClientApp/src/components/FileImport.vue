<template id="file-import-container">
    <v-card id="file-import-card">
        <v-chip id="title"><h1>Wortgitter</h1></v-chip>
        <div id="description-text-container">
            <p id="description-text">Ein Programm zur automatischen Lösung eines Wortgitter-Rätsels funktioniert, indem es das Rätsel mithilfe eines Fotos erkennt und digitalisiert. Durch Bildverarbeitungstechniken werden die Buchstaben im Gitter analysiert, während ein Algorithmus gezielt nach den gesuchten Wörtern sucht. Anschließend gibt das Programm die Lösung direkt aus, indem es die gefundenen Wörter im Gitter hervorhebt.</p>
        </div>
        <v-file-input class="file-input" v-model="file" label="Importieren sie ihr Wortgitter Bild hier:"></v-file-input>
        <div class="button-container">
            <v-btn class="start-button" @click="submitImage" >Starten</v-btn>
        </div>
        <div id="loading-screen-background" v-if="loading">
            <div  id="loading-screen">
                <img src="../assets/loading-gif.gif" alt="Loading..." id="loading-gif"/>
            </div>
        </div>
    </v-card>

</template>

<script>
import { useStore } from '../stores/app';
export default {
    data() {
        return {
            file: null,
            loading: false,
            store: useStore()
        }
    },
    methods: {
        async submitImage() {
            if (!this.file) {
                alert("Importieren sie ein Bild von ihrem Wortgitterrätsel");
                return;
            }
            this.loading = true;
            try {
                console.log("file: ", this.file)
                await this.store.submitImage(this.file).then((response) => {
                    console.log(response)
                    this.loading = false;
                    this.$router.push('result');
                });
            } catch(error) {
                console.error(error);
                alert("Das Bild des Wortgitters konnte nicht Erfolgreich eingelesen werden, bitte fügen sie ein deutlicheres Bild des Wortgitters ein");
                this.loading = false;
                return;
            }
        }
    }
}
</script>

<style lang="css" scoped>
#title {
    margin: 20px 10px 20px 10px;
    width: min-content;
    height: min-content;
    font-size: 20px;
}
#description-text {
    margin: 10px 10px 30px 10px;
    max-width: 95%;
    border-radius: 15px;
    height: min-content;
    white-space: normal;
    word-break: break-word;
    font-size: 17px;
}

#description-text-container {
    display: flex;
    flex-wrap: wrap;
    margin-bottom: 70px;
}

#loading-screen {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
}
#loading-gif {
    height: 50px;
    width: 50px;
}

#loading-screen-background {
    width: 100%;
    height: 100%;
}

.file-input {
    width: 70%;
    margin: auto;
}

.start-button {
    margin: auto;
    width: 100%;
    height: 100px;
    font-size: 30px;
    outline: 2px solid gray;
}

.button-container {
    width: 70%;
    margin: auto;
}
</style>
