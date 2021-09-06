<template>
  <div id="loginform">
    <a-form :model="formState" :label-col="labelCol" :wrapper-col="wrapperCol">
      <a-from-item >
        <login-tabs class="logintabs"></login-tabs>
      </a-from-item>
      <a-form-item label="Activity name">
        <a-input v-model:value="formState.name" />
      </a-form-item>
      <a-form-item label="Activity zone">
        <a-select
          v-model:value="formState.region"
          placeholder="please select your zone"
        >
          <a-select-option value="shanghai">Zone one</a-select-option>
          <a-select-option value="beijing">Zone two</a-select-option>
        </a-select>
      </a-form-item>
      <a-form-item label="Activity time">
        <a-date-picker
          v-model:value="formState.date1"
          show-time
          type="date"
          placeholder="Pick a date"
          style="width: 100%"
        />
      </a-form-item>
      <a-form-item label="Instant delivery">
        <a-switch v-model:checked="formState.delivery" />
      </a-form-item>
      <a-form-item label="Activity type">
        <a-checkbox-group v-model:value="formState.type">
          <a-checkbox value="1" name="type">Online</a-checkbox>
          <a-checkbox value="2" name="type">Promotion</a-checkbox>
          <a-checkbox value="3" name="type">Offline</a-checkbox>
        </a-checkbox-group>
      </a-form-item>
      <a-form-item label="Resources">
        <a-radio-group v-model:value="formState.resource">
          <a-radio value="1">Sponsor</a-radio>
          <a-radio value="2">Venue</a-radio>
        </a-radio-group>
      </a-form-item>
      <a-form-item label="Activity form">
        <a-input v-model:value="formState.desc" type="textarea" />
      </a-form-item>
      <a-form-item :wrapper-col="{ span: 14, offset: 4 }">
        <a-button type="primary" @click="onSubmit">Create</a-button>
        <a-button style="margin-left: 10px">Cancel</a-button>
      </a-form-item>
    </a-form>
  </div>
</template>
<script>
import { defineComponent, reactive, toRaw } from "vue";
import LoginTabls from "./LoginTabs.vue";

export default defineComponent({
  components: { "login-tabs": LoginTabls },
  setup() {
    const formState = reactive({
      name: "",
      region: undefined,
      date1: undefined,
      delivery: false,
      type: [],
      resource: "",
      desc: "",
    });

    const onSubmit = () => {
      console.log("submit!", toRaw(formState));
    };

    return {
      labelCol: {
        span: 4,
      },
      wrapperCol: {
        span: 14,
      },
      formState,
      onSubmit,
    };
  },
});
</script>

<style lang="less" scoped>
#loginform {
  text-align: center;
  // width: 500px;
  .ant-form {
    width: 500px;
    display: block;
    margin-top: 0;
    margin-bottom: 0;
    margin: auto;
    .ant-from-item
    {
      margin: ;
    }
    .logintabs {
      margin: 10px 20px 20px 20px;
    }
  }
}
</style>