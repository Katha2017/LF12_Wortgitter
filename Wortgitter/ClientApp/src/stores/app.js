// Utilities
import { defineStore } from 'pinia';
import ImageService from '../service/ImageService.js';

export const useStore = defineStore('store', {
  state: () => ({
    resultData: null,
  }),
  getters: {
    getResultData: (state) => state.resultData,
  },
  actions: {
    async submitImage(file) {
      await ImageService.requestWordGrid(file).then(
        (response) => { resultData = response}
      )
    },
    setResultData(data) {
      this.resultData = data;
    }
    
  }
})
