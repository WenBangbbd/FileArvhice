<template>
  <a-tabs v-model:activeKey="activeKey">
    <a-tab-pane key="1" tab="Tab 1">
      <div class="components-input-demo-presuffix">
        <a-input placeholder="Basic usage" v-model:value="userName">
          <template #prefix>
            <user-outlined type="user" />
          </template>
          <template #suffix>
            <a-tooltip title="Extra information">
              <info-circle-outlined style="color: rgba(0, 0, 0, 0.45)" />
            </a-tooltip>
          </template>
        </a-input>
        <br />
        <br />
        <a-input prefix="￥" suffix="RMB" />
      </div>
    </a-tab-pane>
    <a-tab-pane key="2" tab="Tab 2" force-render>
      <div class="components-input-demo-presuffix">
        <a-input placeholder="Basic usage" v-model:value="userName">
          <template #prefix>
            <user-outlined type="user" />
          </template>
          <template #suffix>
            <a-tooltip title="Extra information">
              <info-circle-outlined style="color: rgba(0, 0, 0, 0.45)" />
            </a-tooltip>
          </template>
        </a-input>
        <br />
        <br />
        <a-input prefix="￥" suffix="RMB" />
      </div>
    </a-tab-pane>
  </a-tabs>
</template>


<script lang="ts">
import { defineComponent, ref } from "vue";
import { UserOutlined, InfoCircleOutlined } from "@ant-design/icons-vue";
export default defineComponent({
  components: {
    UserOutlined,
    InfoCircleOutlined,
  },
  setup() {
    const userName = ref("");
    return {
      userName,
      activeKey: ref("1"),
    };
  },
});
</script>

